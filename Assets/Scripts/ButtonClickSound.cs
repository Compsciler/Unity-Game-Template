using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioClip[] clickSounds;

    public void PlaySound(int soundNum)
    {
        AudioManager.instance.SFX_Source.PlayOneShot(clickSounds[soundNum]);
    }
}
