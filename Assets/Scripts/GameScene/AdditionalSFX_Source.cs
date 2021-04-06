using UnityEngine;

public class AdditionalSFX_Source : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().mute = (PlayerPrefs.GetInt(Constants.prefsIsSFX_Muted) == 1);
    }
}