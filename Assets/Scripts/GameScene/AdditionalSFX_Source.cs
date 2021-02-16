﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalSFX_Source : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().mute = (PlayerPrefs.GetInt("IsSFX_Muted") == 1);
    }
}