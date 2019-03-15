using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class Restart : MonoBehaviour
{
    public  RewardBasedVideoAd rewardBasedVideo;
    private void OnMouseDown()
    {
        Application.LoadLevel("Game_v1");
    }
}
