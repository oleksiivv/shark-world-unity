using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsSpawner : MonoBehaviour
{
    public GameObject heart;
    private SharkHealthBar playerHealth;

    public GameObject[] sharks;


    void Start(){
        StartCoroutine(spawner());

        playerHealth=sharks[PlayerPrefs.GetInt("current",0)].GetComponent<SharkHealthBar>();
    }


    IEnumerator spawner(){
        while(true){
            yield return new WaitForSeconds(3);

            if(playerHealth.healthSlider.value<80 && SharkHealthBar.alive){
                Instantiate(heart, new Vector3(Random.Range(-2.5f,2.5f), 6, 0), heart.transform.rotation);
            }
        }
    }
}
