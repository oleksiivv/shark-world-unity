using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSwicther : MonoBehaviour
{
    public GameObject[] cars;
    
    public int currId;

    private List<ShopItem> items=new List<ShopItem>();

    public GameObject chooseBtn;
    public GameObject[] buyEquipment;
    public Text[] prices;

    public ParticleSystem buyEffect;

    public Text currentItemName;

    public Text coinsCurrent, hiCurrent;

    public bool canBeChoosen=true;

    public MapSiwtcher map;

    void Start(){
        //PlayerPrefs.SetInt("coins",5000);
        //PlayerPrefs.SetInt("hi",2000);
        if(PlayerPrefs.GetInt("firstGame",-1)==-1){
            PlayerPrefs.SetInt("coins",100);
            PlayerPrefs.SetInt("firstGame",1);
        }

        coinsCurrent.text=PlayerPrefs.GetInt("coins").ToString();
        hiCurrent.text=PlayerPrefs.GetInt("hi").ToString();

        items.Add(new ShopItem(0,000,"Default Shark"));
        items.Add(new ShopItem(1,150,"Ghost"));
        items.Add(new ShopItem(2,350,"Tiger"));
        items.Add(new ShopItem(3,650,"Blackest Night"));
        

        currId=PlayerPrefs.GetInt("current",0);
        show(currId);

        for(int i=0;i<items.Count;i++){
            prices[i].text=items[i].price.ToString();
        }
    }

    public void next(){
        currId++;
        if(currId>=cars.Length){
            currId=0;
        }

        show(currId);
    }

    public void prev(){
        currId--;
        if(currId<0){
            currId=cars.Length-1;
        }

        show(currId);
    }

    void show(int id){
        hideAll();

        cars[id].SetActive(true);
        currentItemName.text=items[id].name;

        if(PlayerPrefs.GetInt("Car@"+id.ToString())==1 || id==0){
            buyEquipment[id].SetActive(false);
            
            if(map.canBeChoosen)chooseBtn.SetActive(true);
            canBeChoosen=true;
        }
        else{
            buyEquipment[id].SetActive(true);
            chooseBtn.SetActive(false);
            canBeChoosen=false;
        }
    }

    void hideAll(){
        foreach(var obj in cars){
            obj.SetActive(false);
        }

        foreach(var eq in buyEquipment){
            eq.SetActive(false);
        }
    }


    ////
    public GameObject[] studyPanel;
    public void choose(){
         if(PlayerPrefs.GetInt("studied",-1)==-1){
             foreach(var detail in studyPanel)detail.SetActive(true);
             PlayerPrefs.SetInt("studied",1);
         }
         else{
            PlayerPrefs.SetInt("currentMap",map.currId);
            PlayerPrefs.SetInt("current",currId);
            StartCoroutine(loadAsync(2));
            //Application.LoadLevel(2);
        }
    }

    public void confirmStudy(){
        PlayerPrefs.SetInt("studied",1);
        PlayerPrefs.SetInt("current",currId);
        StartCoroutine(loadAsync(2));
    }



    public void showAvailable(){
        for(int i=0;i<items.Count;i++){
            if(PlayerPrefs.GetInt("Car@"+i.ToString())==1){
                buyEquipment[i].SetActive(false);
            }
            else{
                buyEquipment[i].SetActive(true);
            }
        }
    }

    public void buy(int id){
        if(PlayerPrefs.GetInt("coins")>=items[id].price){
            PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")-items[id].price);

            items[id].buy();
            show(id);

            buyEffect.Play();
            coinsCurrent.text=PlayerPrefs.GetInt("coins").ToString();
        }
    }

    public void openScene(int id){
        StartCoroutine(loadAsync(id));
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
