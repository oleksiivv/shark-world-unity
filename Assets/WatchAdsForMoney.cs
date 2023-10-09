using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;

public class WatchAdsForMoney : RewardedVideo
{
    private RewardedAd rewardBasedVideo;

#if UNITY_IOS
    private string appId = "ca-app-pub-4962234576866611/5127458153";
    private string rewardedId = "ca-app-pub-4962234576866611/5127458153";

    private string gameID="4250866";
#else
    private string appId = "ca-app-pub-4962234576866611~3885729647";
    private string rewardedId = "ca-app-pub-4962234576866611/8391710589";

    private string gameID="4250867";
#endif


    public Text coins;

    void Start(){
        Advertisement.Initialize(gameID, false);
        
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        MobileAds.Initialize(initStatus => {
            InitAdmobRewarded();
        });

        LoadAd();
    }


    private RewardedAd _rewardedAd;
    void InitAdmobRewarded(){
      if (_rewardedAd != null)
      {
            _rewardedAd.Destroy();
            _rewardedAd = null;
      }

      Debug.Log("Loading the rewarded ad.");

      // create our request used to load the ad.
      var adRequest = new AdRequest();

      // send the request to load the ad.
      RewardedAd.Load(rewardedId, adRequest,
          (RewardedAd ad, LoadAdError error) =>
          {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
              {
                  return;
              }

              _rewardedAd = ad;

              RegisterReloadHandler(_rewardedAd);
              RegisterEventHandlers(_rewardedAd);
          });
    }
    
    private bool ShowRewardBasedGoogleVideo()
    {
      const string rewardMsg =
        "Rewarded ad rewarded the user";

        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
          Time.timeScale=0;
            _rewardedAd.Show((Reward reward) =>
            {
              Success();
            });

            return true;
        }
        
        return false;
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
      // Raised when the ad is estimated to have earned money.
      ad.OnAdPaid += (AdValue adValue) =>
      {
          Success();

      };
      // Raised when an impression is recorded for an ad.
      ad.OnAdImpressionRecorded += () =>
      {
          Debug.Log("Rewarded ad recorded an impression.");
      };
      // Raised when a click is recorded for an ad.
      ad.OnAdClicked += () =>
      {
          Debug.Log("Rewarded ad was clicked.");
      };
      // Raised when an ad opened full screen content.
      ad.OnAdFullScreenContentOpened += () =>
      {
          Debug.Log("Rewarded ad full screen content opened.");
      };
      // Raised when the ad closed full screen content.
      ad.OnAdFullScreenContentClosed += () =>
      {
          Debug.Log("Rewarded ad full screen content closed.");
      };
      // Raised when the ad failed to open full screen content.
      ad.OnAdFullScreenContentFailed += (AdError error) =>
      {
          Debug.LogError("Rewarded ad failed to open full screen content " +
                        "with error : " + error);
      };
  }

  private void RegisterReloadHandler(RewardedAd ad)
  {
      // Raised when the ad closed full screen content.
      ad.OnAdFullScreenContentClosed += () =>
      {
          Debug.Log("Rewarded Ad full screen content closed.");

          // Reload the ad so that we can show another as soon as possible.
          InitAdmobRewarded();
      };
      // Raised when the ad failed to open full screen content.
      ad.OnAdFullScreenContentFailed += (AdError error) =>
      {
          Debug.LogError("Rewarded ad failed to open full screen content " +
                        "with error : " + error);

          // Reload the ad so that we can show another as soon as possible.
          InitAdmobRewarded();
      };
  }

    private bool ShowRewardBasedVideo()
    {
        return ShowRewardBasedGoogleVideo();
    }

    public void showAdsForMoney(){
        if(!ShowRewardBasedVideo()){
            this.ShowAd();
        }
    }

    public override void Success(){
        PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")+20);
        coins.text=PlayerPrefs.GetInt("coins").ToString();
    }

    void AdCallbackHandler(ShowResult res)
      {
          if (res == ShowResult.Finished)
          {
            //reward
            PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")+20);
            coins.text=PlayerPrefs.GetInt("coins").ToString();

          }
          else if (res == ShowResult.Skipped)
          {
              Debug.Log("skipped");
          }
          else if (res == ShowResult.Skipped)
          {
              Debug.Log("error");
          }
      }
}
