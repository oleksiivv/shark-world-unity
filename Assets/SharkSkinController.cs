using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSkinController : MonoBehaviour
{
    public GameObject[] sharks;

    int curr;
    void Start()
    {
        curr=PlayerPrefs.GetInt("current",0);
        
        hideAll();
        show(curr);
    }

    void hideAll(){
        foreach(var shark in sharks)shark.SetActive(false);
    }

    void show(int id){
        sharks[id].SetActive(true);
    }
}
