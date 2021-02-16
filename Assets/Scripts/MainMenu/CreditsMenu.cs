﻿using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    private string linkUrl = "https://www.cdc.gov/coronavirus/2019-ncov/prevent-getting-sick/social-distancing.html";

    public void OpenLink()
    {
        Application.OpenURL(linkUrl);
    }
}