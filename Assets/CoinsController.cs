using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    public Text coinsText;

    void Start(){
        coinsText.text=PlayerPrefs.GetInt("coins").ToString();
    }

    public void updateCoinsValue(int n=1){
        PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")+n);
        coinsText.text=PlayerPrefs.GetInt("coins").ToString();
    }
}
