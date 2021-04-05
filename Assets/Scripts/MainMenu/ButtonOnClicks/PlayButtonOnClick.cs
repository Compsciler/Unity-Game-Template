using UnityEngine;

public class PlayButtonOnClick : MonoBehaviour
{
    [SerializeField] int gameMode;

    [SerializeField] GameObject difficultySelectMenu;

    public void OnClickFunction()
    {
        difficultySelectMenu.GetComponent<DifficultySelectMenu>().Play(gameMode);
    }
}