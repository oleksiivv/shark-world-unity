using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemySpawner : MonoBehaviour
{
    public GameObject[] mediumEnemy;
    public float spawnPosY;
    private float delay=8f;
    //public SharkHealthBar shark;


    void Start(){
        StartCoroutine(spawn());
    }





    IEnumerator spawn(){
        while(true){
            yield return new WaitForSeconds(delay);

            int n=Random.Range(0, mediumEnemy.Length);
            Instantiate(mediumEnemy[n], new Vector3(Random.Range(-1.75f,1.75f), spawnPosY,0), mediumEnemy[n].transform.rotation);

            if(delay>5)delay*=0.99f;
            
        }
    }
            
}
