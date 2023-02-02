using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public Vector3 spawnPos;
    public float wallLength;

    private float speed=1f;


    void Update(){
        if(speed<3f)speed*=1.0005f;

        //Debug.Log("Wall speed: "+speed.ToString());

        if(SharkHealthBar.alive)transform.position=Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,spawnPos.y, transform.position.z), 0.025f*Time.timeScale);

        if(transform.position.y==spawnPos.y){
            cleanChilds();
            transform.position+=new Vector3(0,wallLength*2,0);
        }
    }

    void cleanChilds(){
        for(int i=0;i<gameObject.transform.childCount;i++){
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }
}
