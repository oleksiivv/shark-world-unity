using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    
    void Start(){
        Application.targetFrameRate=30;
    }

    void Update(){
     
        Vector3 relativePos = player.transform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.Euler(0,0,Quaternion.RotateTowards(transform.rotation,rotation,22.5f).z*-180);
        
    }
}
