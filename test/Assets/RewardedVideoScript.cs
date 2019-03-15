 using System;
 using UnityEngine;
 using GoogleMobileAds;
 using GoogleMobileAds.Api;
 using System.Collections;
 public class RewardedVideoScript : MonoBehaviour
 {
     const string adUnitIdRewardedVideo = "ca-app-pub-3940256099942544/5224354917";   // Your Key
     protected  RewardBasedVideoAd rewardBasedVideo;
 
     void OnEnable ()
     {
         
         rewardBasedVideo = RewardBasedVideoAd.Instance;
         // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
         rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
 
     }
     void Start ()
     {
         RequestRewardBasedVideo ();
     }
     void OnDisable ()
     {
         rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
     }
     protected AdRequest createAdRequest ()
     {
         AdRequest request = new AdRequest.Builder ().AddTestDevice(AdRequest.TestDeviceSimulator).Build();       // Simulator.
         //        .AddTestDevice("E32C2E79AD1DAE9D9AE99EF4F61E80ED")  // My test device.
                // .Build();
         return request;
     }
 
     public void RequestRewardBasedVideo ()
     {
 
         rewardBasedVideo.LoadAd (createAdRequest (), adUnitIdRewardedVideo);
     
     }
 
     public void ShowRewardBasedVideo ()
     {
 
         if (rewardBasedVideo.IsLoaded ()) {
             rewardBasedVideo.Show ();
         } else {
             RequestRewardBasedVideo ();
         }
 
     }
     public void HandleRewardBasedVideoRewarded (object sender, Reward args)
     {
         //Call your function here
 
     }
 }