using UnityEngine;

// Attached to GameObjects with SFX not played from AudioManager.instance.SFX_Source (e.g. animation sounds)
public class AdditionalSFX_Source : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().mute = (PlayerPrefs.GetInt(Constants.prefsIsSFX_Muted) == 1);
    }
}