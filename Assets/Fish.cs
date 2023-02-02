using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed=1;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x<-2.4 || transform.position.x>2.4f){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*1/20*Time.timeScale);
    }
}
