using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(!other.gameObject.name.ToUpper().Contains("floor")){
            Destroy(other.gameObject);
        }
    }
}
