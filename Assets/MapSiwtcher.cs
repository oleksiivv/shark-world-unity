using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSiwtcher : MonoBehaviour
{
    public bool canBeChoosen=true;

    public GameObject[] maps;
    public GameObject[] lockers;
    public int currId;

    public GameObject chooseBtn;
    public CarSwicther shark;

    public int[] requiredHI;
    public Text[] requiredHiText;


    void Start(){
        //PlayerPrefs.SetInt("hi",800);

        int n=PlayerPrefs.GetInt("hi");
        for(int i=requiredHI.Length-1;i>=0;i--){
            if(n>=requiredHI[i]){
                PlayerPrefs.SetInt("Map@"+i.ToString(),1);
            }
        }
        for(int i=0;i<requiredHI.Length;i++){
            requiredHiText[i].text="Required HI>"+requiredHI[i].ToString();
        }


        currId=PlayerPrefs.GetInt("currentMap",0);
        show(currId);
    }

    public void next(){
        currId++;
        if(currId>=maps.Length){
            currId=0;
        }

        show(currId);
    }

    public void prev(){
        currId--;
        if(currId<0){
            currId=maps.Length-1;
        }

        show(currId);
    }

    void show(int id){
        hideAll();

        maps[id].SetActive(true);

        if(PlayerPrefs.GetInt("Map@"+id.ToString())==1 || id==0){
            lockers[id].SetActive(false);

            if(shark.canBeChoosen)chooseBtn.SetActive(true);
            canBeChoosen=true;
        }
        else{
            lockers[id].SetActive(true);

            chooseBtn.SetActive(false);
            canBeChoosen=false;
        }
    }

    void hideAll(){
        foreach(var obj in maps){
            obj.SetActive(false);
        }
    }
}
