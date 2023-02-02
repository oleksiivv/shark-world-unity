using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    public GameObject coin;

    //public HealthBar health;

    void Start(){
        StartCoroutine(heartsGenerator());
    }
    IEnumerator heartsGenerator(){
        while(true){
            yield return new WaitForSeconds(Random.Range(3f,10f));

            int n=Random.Range(0,5);
            if(n==1){
                Instantiate(coin, new Vector3(-1f, 8, 0), coin.transform.rotation);
                Instantiate(coin, new Vector3(0, 8, 0), coin.transform.rotation);
                Instantiate(coin, new Vector3(1f, 8, 0), coin.transform.rotation);
            }
            else if(n==2){
                float pos=Random.Range(-0.5f,0.5f);
                Instantiate(coin, new Vector3(pos, 8, 0), coin.transform.rotation);
                Instantiate(coin, new Vector3(pos, 9f, 0), coin.transform.rotation);
                Instantiate(coin, new Vector3(pos, 10f, 0), coin.transform.rotation);
            }
            else{
                float pos=Random.Range(-0.5f,0.5f);
                Instantiate(coin, new Vector3(pos, 8, 0), coin.transform.rotation);
            }
        }
    }
}
