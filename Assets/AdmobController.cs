using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobController : MonoBehaviour
{
    private InterstitialAd intersitional;

#if UNITY_IOS
    private string appId="ca-app-pub-4962234576866611~9449846549";
    private string intersitionalId="ca-app-pub-4962234576866611/7945193184";
#else
    private string appId="ca-app-pub-4962234576866611~3885729647";
    private string intersitionalId="ca-app-pub-4962234576866611/5062601019";
#endif
    //private string bannerId="ca-app-pub-4962234576866611/8956237275";
    
    public void init(){
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);
        
        MobileAds.Initialize(initStatus => {
            LoadLoadInterstitialAd();
        });
        //RequestBannerAd();        
    }

     AdRequest AdRequestBuild(){
         return new AdRequest.Builder().Build();
     }


      public bool showIntersitionalAd(){
          return showIntersitionalGoogleAd();
      }
      
      private InterstitialAd _interstitialAd;
    
    public void LoadLoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
                _interstitialAd.Destroy();
                _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(intersitionalId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                    "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                            + ad.GetResponseInfo());

                _interstitialAd = ad;
                
                RegisterEventHandlers(_interstitialAd);
                RegisterReloadHandler(_interstitialAd);
            });
    }


      public bool showIntersitionalGoogleAd(){
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.Show();

            return true;
        }
        else
        {
            return false;
        }
      }

      private void RegisterEventHandlers(InterstitialAd interstitialAd)
      {
          interstitialAd.OnAdPaid += (AdValue adValue) =>
          {
              Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
                  adValue.Value,
                  adValue.CurrencyCode));
          };

          interstitialAd.OnAdImpressionRecorded += () =>
          {
              Debug.Log("Interstitial ad recorded an impression.");
          };

          interstitialAd.OnAdClicked += () =>
          {
              Debug.Log("Interstitial ad was clicked.");
          };

          interstitialAd.OnAdFullScreenContentOpened += () =>
          {
              Debug.Log("Interstitial ad full screen content opened.");
          };

          interstitialAd.OnAdFullScreenContentClosed += () =>
          {
              Debug.Log("Interstitial ad full screen content closed.");
          };

          interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
          {
              Debug.LogError("Interstitial ad failed to open full screen content " +
                          "with error : " + error);
          };
      }

      private void RegisterReloadHandler(InterstitialAd interstitialAd)
      {
          interstitialAd.OnAdFullScreenContentClosed += () =>
          {
              Debug.Log("Interstitial Ad full screen content closed.");

              LoadLoadInterstitialAd();
          };

          interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
          {
              Debug.LogError("Interstitial ad failed to open full screen content " +
                          "with error : " + error);

              LoadLoadInterstitialAd();
          };
      }
}