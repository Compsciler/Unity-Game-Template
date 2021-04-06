using MEC;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] AudioClip restartButtonClickSound;
    [SerializeField] AudioClip goToMainMenuButtonClickSound;

    [SerializeField] GameObject mainCamera;

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
}