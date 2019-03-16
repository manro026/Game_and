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
    
    private static ILogger logger = Debug.unityLogger;
     internal void Start() {
        rewardBasedVideo = RewardBasedVideoAd.Instance;
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        MobileAds.Initialize("ca-app-pub-3254112346644116~7744970686");
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
            
     }
     public void RequestRewardBasedVideo ()
     {
         rewardBasedVideo.LoadAd (new AdRequest.Builder().Build(), "ca-app-pub-3254112346644116/5107145158");
     
     }
     public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        game = GameObject.FindWithTag("panel").GetComponent<Game>();
        gameover = GameObject.FindWithTag("gameover");
        Destroy(gameover);
        Destroy(game.list);
        game.Spawn_list();
        
    }
 }