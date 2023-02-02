using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class SharkUI : MonoBehaviour
{
    public GameObject pausePanel, deathPanel;
#if UNITY_IOS
    private string gameID="4250866";
#else
    private string gameID="4250867";
#endif
    public AdmobController admob;

    void Start(){
        Advertisement.Initialize(gameID, false);

        admob.init();
    }

    public void showDeathPanel(){
        Invoke(nameof(innerShowDeathPanel),1f);
    }

    public void setPausePanelVisible(bool visible){
        pausePanel.SetActive(visible);
    }

    void innerShowDeathPanel(){

        // if(MainSceneUI.addCnt%2==0){
        //     if(Advertisement.IsReady() ){
        //         Advertisement.Show("Interstitial_Android");
        //     }
        //     else{
        //         admob.showIntersitionalAd();
        //     }
        // }
        // MainSceneUI.addCnt++;
        deathPanel.SetActive(true);

        if(MainSceneUI.addCnt%2==0){
            if(!admob.showIntersitionalAd()){
                if(Advertisement.IsReady("Interstitial_Android")){
                    Advertisement.Show("Interstitial_Android");
                }
                else{
                    admob.showIntersitionalAd();
                }
            }
        }
        MainSceneUI.addCnt++;
    }

}
