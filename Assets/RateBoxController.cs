using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateBoxController : MonoBehaviour
{
    public GameObject ratePanel;

    public static int opened=0;

    void Start(){
        if(opened==2 && PlayerPrefs.GetInt("rated",0)==0){
            ratePanel.SetActive(true);
        }
        else{
            ratePanel.SetActive(false);
        }

        opened++;
    }

    public void rate(){
        PlayerPrefs.SetInt("rated",1);
        ratePanel.SetActive(false);

        Application.OpenURL("https://play.google.com/store/apps/details?id=com.EasyStreet.SharkWorld");
    }

    public void rateLater(){
        opened=5;
        ratePanel.SetActive(false);
    }

    public void rateNewer(){
        PlayerPrefs.SetInt("rated",1);
        ratePanel.SetActive(false);
    }
}
