using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class Restart : MonoBehaviour
{
    
    private void OnMouseDown()
    {
        Application.LoadLevel("Game_v1");
    }
}
