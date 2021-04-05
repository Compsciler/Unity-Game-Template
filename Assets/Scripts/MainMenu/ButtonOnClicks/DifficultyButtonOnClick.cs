using System;
using UnityEngine;

public class DifficultyButtonOnClick : MonoBehaviour
{
    [SerializeField] GameObject pressedButtonImage;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject descriptionText;
    [SerializeField] AudioClip buttonClickSound;

    [SerializeField] GameObject difficultySelectMenu;
    [SerializeField] GameObject mainCamera;

    public void OnClickFunction()
    {
        difficultySelectMenu.GetComponent<DifficultySelectMenu>().ResetMenuPresses();
        pressedButtonImage.SetActive(true);
        descriptionText.SetActive(true);
        mainCamera.GetComponent<ButtonClickSound>().PlaySound(buttonClickSound);

        try
        {
            startButton.SetActive(true);
        }
        catch (UnassignedReferenceException)
        {

        }
    }
}