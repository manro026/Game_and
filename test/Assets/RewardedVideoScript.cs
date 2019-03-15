 using System;
 using UnityEngine;
 using GoogleMobileAds;
 using GoogleMobileAds.Api;
 using System.Collections;
 public class RewardedVideoScript : MonoBehaviour
 {
    const string adUnitIdRewardedVideo = "ca-app-pub-3940256099942544/5224354917";   // Your Key
    public  RewardBasedVideoAd rewardBasedVideo;
    private Game game;
    private GameObject gameover;
     internal void Start() {
        game = GameObject.FindWithTag("panel").GetComponent<Game>();
        gameover = GameObject.FindWithTag("gameover");
        rewardBasedVideo = RewardBasedVideoAd.Instance;
        MobileAds.Initialize("ca-app-pub-3940256099942544~3347511713");
        RequestRewardBasedVideo ();
     }
     private void OnMouseDown()
     {
         rewardBasedVideo.Show ();
     }
     public void RequestRewardBasedVideo ()
     {
         rewardBasedVideo.LoadAd (new AdRequest.Builder ()
      .AddTestDevice ("899D4765E14315B984A6EBF2C6A48441")
      .Build (), adUnitIdRewardedVideo);
     
     }
     public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        game.timer_flag=false;
        Destroy(gameover);
    }
 }