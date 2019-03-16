 using System;
 using UnityEngine;
 using GoogleMobileAds;
 using GoogleMobileAds.Api;
 using System.Collections;
 public class RewardedVideoScript : MonoBehaviour
 {
    public  RewardBasedVideoAd rewardBasedVideo;
    private Game game;
    private GameObject gameover;
    private bool watched=false;
    private static ILogger logger = Debug.unityLogger;
     internal void Start() {
        rewardBasedVideo = RewardBasedVideoAd.Instance;
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        MobileAds.Initialize("ca-app-pub-3254112346644116~7744970686");
        game = GameObject.FindWithTag("panel").GetComponent<Game>();
        gameover = GameObject.FindWithTag("gameover");
        watched=false;
        RequestRewardBasedVideo ();
     }
     private void OnMouseDown()
     {
        if (rewardBasedVideo.IsLoaded()) {
            rewardBasedVideo.Show();
            }
        else{
            RequestRewardBasedVideo ();
            }
        if (game.timer<25){
            game.timer=25f;
        }
        game.enabled = false;
     }
     public void Update(){
         if (watched){
        Destroy(game.list);
        Destroy(gameover);
        game.Spawn_list();
         }
     }
     public void RequestRewardBasedVideo ()
     {
         rewardBasedVideo.LoadAd (new AdRequest.Builder().Build(), "ca-app-pub-3254112346644116/5107145158");
     
     }
     public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        watched=true;
    }
 }