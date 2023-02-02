using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class MainSceneUI : MonoBehaviour
{
    public SharkUI[] sharkUI;


#if UNITY_IOS
    private string gameID="4250866";
#else
    private string gameID="4250867";
#endif

    public static int addCnt=1;

    public AdmobController admob;

    void Start(){
        Advertisement.Initialize(gameID, false);
        admob.init();
    }

    void Update(){
        Time.timeScale = sharkUI[PlayerPrefs.GetInt("current",0)].pausePanel.gameObject.activeSelf ? 0 : 1;
    }


    public void pause(){
        Time.timeScale=0;
        sharkUI[PlayerPrefs.GetInt("current",0)].setPausePanelVisible(true);

        PlayerPrefs.SetInt("first",1);

        if(addCnt%2==0){
            if(!admob.showIntersitionalAd()){
                if(Advertisement.IsReady("Interstitial_Android")){
                    Advertisement.Show("Interstitial_Android");
                }
                else{
                    admob.showIntersitionalAd();
                }
            }
        }
        addCnt++;
    }

    public void resume(){
        Time.timeScale=1;
        sharkUI[PlayerPrefs.GetInt("current",0)].setPausePanelVisible(false);

        PlayerPrefs.SetInt("first",1);
    }


    public void openScene(int id){
        Time.timeScale=1;

        // if(Advertisement.IsReady() && addCnt%2==0){
        //     Advertisement.Show("Interstitial_Android");
        // }
        // addCnt++;

        StartCoroutine(loadAsync(id));

        PlayerPrefs.SetInt("first",1);
    }

    public void restart(){
        openScene(Application.loadedLevel);
    }

    public GameObject loadingPanel;
    public Slider loadingSlider;
    IEnumerator loadAsync(int id)
    {
        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            yield return null;

        }
    }
}
