using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkScore : MonoBehaviour
{
    public Text score, hi;

    public Text newHiLabel;
    public int iscore{get; private set;}

    void Start(){
        iscore=0;

        score.text=iscore.ToString();
        hi.text=PlayerPrefs.GetInt("hi",0).ToString();

    }

    private bool showed=false;
    public void changeScore(int n=1){
        iscore+=n;
        score.text=iscore.ToString();

        if(iscore>PlayerPrefs.GetInt("hi",-1)){
            
            PlayerPrefs.SetInt("hi",iscore);
            hi.text=PlayerPrefs.GetInt("hi",0).ToString();

            if(!showed && PlayerPrefs.GetInt("first",-1)!=-1){
                showed=true;
                PlayerPrefs.SetInt("first",1);
                showNewHiLabel();
            }
        }
    }

    public void showNewHiLabel(){
        newHiLabel.gameObject.SetActive(true);

        Invoke(nameof(resetNewHiLabel), 3f);
    }

    void resetNewHiLabel(){
        newHiLabel.gameObject.SetActive(false);
    }


}
