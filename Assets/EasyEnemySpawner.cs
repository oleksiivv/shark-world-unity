using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemySpawner : MonoBehaviour
{
    public GameObject[] fishes;
    public float spawnPosY;
    private float delayCoef=1;
    //public SharkHealthBar shark;


    void Start(){
        StartCoroutine(spawn());
    }





    IEnumerator spawn(){
        while(true){
            
            int opt=Random.Range(0,6);
            if(opt==0){
                int n=Random.Range(0, fishes.Length);
                Instantiate(fishes[n], new Vector3(Random.Range(-2.5f,2.5f), spawnPosY,0), fishes[n].transform.rotation);
            }
            else if(opt==1){
                float pos=Random.Range(-2f,2f);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos, spawnPosY,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos+1, spawnPosY+1,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos-1, spawnPosY+1,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
            }
            else if(opt>1 && opt<4){
                float pos=Random.Range(-2f,2f);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos, spawnPosY,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos+1, spawnPosY+1,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos-1, spawnPosY+1,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos, spawnPosY,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos+1, spawnPosY-1,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos-1, spawnPosY-1,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
            }
            else{
                float pos=Random.Range(-2f,0f);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos, spawnPosY,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos+1, spawnPosY+1,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos-1, spawnPosY+1,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                float pos2=Random.Range(0f,2f);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos2, spawnPosY,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos2+1, spawnPosY+1,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
                Instantiate(fishes[Random.Range(0, fishes.Length)], new Vector3(pos2-1, spawnPosY+1,0), fishes[Random.Range(0, fishes.Length)].transform.rotation);
            }

            if(delayCoef>0.3f)delayCoef*=0.992f;
            Debug.Log("Delay: "+delayCoef.ToString());
            yield return new WaitForSeconds(Random.Range(0.35f,2.5f)*delayCoef);
        }
    }
}
