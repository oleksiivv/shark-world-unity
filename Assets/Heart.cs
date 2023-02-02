using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{   

    void Update(){
        transform.position=Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,-15, transform.position.z), 0.04f*Time.timeScale);
    }
}
