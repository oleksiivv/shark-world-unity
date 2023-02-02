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
        
        MobileAds.Initialize(initStatus => { });
        //RequestBannerAd();
        RequestConfigurationAd();
        
    }

     AdRequest AdRequestBuild(){
         return new AdRequest.Builder().Build();
     }


      void RequestConfigurationAd(){
          intersitional=new InterstitialAd(intersitionalId);
          AdRequest request=AdRequestBuild();
          intersitional.LoadAd(request);

          intersitional.OnAdLoaded+=this.HandleOnAdLoaded;
          intersitional.OnAdOpening+=this.HandleOnAdOpening;
          intersitional.OnAdClosed+=this.HandleOnAdClosed;

      }


      public bool showIntersitionalAd(){
          if(intersitional.IsLoaded()){
              //Time.timeScale = 0;
              intersitional.Show();

              return true;
          }

          return false;
      }

      private void OnDestroy(){
          

          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

          DestroyIntersitional();

      }

      private void HandleOnAdClosed(object sender, EventArgs e)
      {
          ///Time.timeScale = 0;
          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

            RequestConfigurationAd();

        
      }

      private void HandleOnAdOpening(object sender, EventArgs e)
    {
        ///Time.timeScale = 0;
    }

    private void HandleOnAdLoaded(object sender, EventArgs e)
    {
        ///Time.timeScale = 0;
    }

 

     public void DestroyIntersitional(){
         intersitional.Destroy();
         ///Time.timeScale = 0;
     }




    /*//baner

    public void RequestBannerAd(){
        banner=new BannerView(bannerId,AdSize.Banner,AdPosition.Bottom);
        AdRequest request = AdRequestBannerBuild();
        banner.LoadAd(request);
    }

    public void DestroyBanner(){
        if(banner!=null){
            banner.Destroy();
        }
    }



    AdRequest AdRequestBannerBuild(){
        return new AdRequest.Builder().Build();
    }
    */
}
