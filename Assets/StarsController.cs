using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour
{
    public GameObject star;

    void Start(){
        StartCoroutine(spawner());
    }

    int cnt=0;
    IEnumerator spawner(){
        while(true){
            
            if(cnt==0)yield return new WaitForSeconds(8);
            else yield return new WaitForSeconds(Random.Range(20,25));

            cnt++;

            Instantiate(star, new Vector3(Random.Range(-1.75f,1.75f), 6, 0), star.transform.rotation);
        }
    }
}
