using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float spawnPosY;

    public GameObject[] objects;

    void Start(){
        StartCoroutine(parallax());
    }

    IEnumerator parallax(){
        while(true){
            int n=Random.Range(0, objects.Length);
            Instantiate(objects[n], new Vector3(Random.Range(-2,2), spawnPosY, 0), objects[n].transform.rotation);

            yield return new WaitForSeconds(Random.Range(0.4f,1.5f));
        }
    }
}
