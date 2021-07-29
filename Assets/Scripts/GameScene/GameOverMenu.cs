using MEC;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text descriptionText;

    [SerializeField] GameObject fadingMaskGO;
    [SerializeField] float fadeInTime;
    [SerializeField] float minTransparency;
    [SerializeField] float maxTransparency;

    [SerializeField] AudioClip restartButtonClickSound;
    [SerializeField] AudioClip goToMainMenuButtonClickSound;

    [SerializeField] GameObject mainCamera;

    public IEnumerator<float> GameOver()
    {
        GameManager.instance.isGameActive = false;
        GameManager.instance.pauseButton.GetComponent<Button>().interactable = false;
        if (GameManager.instance.isTutorial)
        {
            Timing.KillCoroutines();

            titleText.text = "TUTORIAL\nCOMPLETE";
            descriptionText.text = "";
            gameObject.SetActive(true);
            Debug.Log("Tutorial Complete!");

            if (PlayerPrefs.GetInt(Constants.prefsStoreReviewRequestTotal, 0) == 0)  //{ Optional: Add more non-tutorial conditions to be ready to request store review
            {
                RateGame.isReadyToRequestStoreReview = true;
            }
            yield return Timing.WaitForOneFrame;
        }
        else if (GameManager.instance.isUsingGameOver)
        {
            // JUST BEFORE REVIVE SCREEN
            Timing.PauseCoroutines();  // Not perfect solution if second chance used, hopefully no coroutines will be used during Game Over screen
            Timing.ResumeCoroutines("GameOver");

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(FadeObjectsBehindMenu()));

            if ((AdManager.instance.adsWatchedTotal < AdManager.instance.maxAdsWatchedPerGame) && Constants.isMobilePlatform)
            {
                GameManager.instance.adMenu.SetActive(true);
                yield return Timing.WaitUntilDone(Timing.RunCoroutine(AdManager.instance.InfiniteWaitToBreakFrom().CancelWith(GameManager.instance.adMenu)));
                Debug.Log("FINISHED");
                if (AdManager.instance.isAdCompleted)
                {
                    GameManager.instance.ResetInfectionTimers();
                    GameManager.instance.isGameActive = true;  // FIRST?
                    fadingMaskGO.SetActive(false);
                    GameManager.instance.pauseButton.GetComponent<Button>().interactable = true;
                    Debug.Log("YIELD BREAK");
                    yield break;
                }
            }

            // GAME OVER SCREEN
            gameObject.SetActive(true);
            GameManager.instance.spawnPeopleScript.UpdateGameOverScoreText();  //{ Update game over text in GameOverMenu.cs instead
            AudioManager.instance.musicSource.Pause();
            AudioManager.instance.SFX_Source.PlayOneShot(GameManager.instance.gameOverSound, GameManager.instance.gameOverSoundVolume);
            Debug.Log("Game Over!");

            int newScore = GameManager.instance.spawnPeopleScript.CalculateScore();
            HighScoreManager.instance.UpdateHighScore(newScore, false);
        }
    }

    public void Restart()
    {
        Timing.KillCoroutines();
        mainCamera.GetComponent<ButtonClickSound>().PlaySound(restartButtonClickSound);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

        // ResetStaticVariables() delegate in GameManager.cs on scene unload
    }

    public void GoToMainMenu()
    {
        Timing.KillCoroutines();
        mainCamera.GetComponent<ButtonClickSound>().PlaySound(goToMainMenuButtonClickSound);
        SceneManager.LoadSceneAsync(Constants.mainMenuBuildIndex);

        // ResetStaticVariables() delegate in GameManager.cs on scene unload
    }

    public IEnumerator<float> FadeObjectsBehindMenu()
    {
        fadingMaskGO.SetActive(true);
        float timer = 0;
        while (timer < fadeInTime)
        {
            Color maskColor = fadingMaskGO.GetComponent<Image>().color;
            fadingMaskGO.GetComponent<Image>().color = new Color(maskColor.r, maskColor.g, maskColor.b, Mathf.Lerp(minTransparency, maxTransparency, timer / fadeInTime));
            timer += Time.deltaTime;
            yield return Timing.WaitForOneFrame;
        }
    }
}