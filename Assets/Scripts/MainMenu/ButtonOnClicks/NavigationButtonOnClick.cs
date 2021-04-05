using UnityEngine;

public class NavigationButtonOnClick : MonoBehaviour
{
    [SerializeField] GameObject currentMenu;
    [SerializeField] GameObject nextMenu;
    [SerializeField] AudioClip buttonClickSound;

    [SerializeField] GameObject mainCamera;

    public void OnClickFunction()
    {
        currentMenu.SetActive(false);
        nextMenu.SetActive(true);
        mainCamera.GetComponent<ButtonClickSound>().PlaySound(buttonClickSound);
    }
}