using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxObject : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float speed;

    void Start(){
        sprite=gameObject.GetComponent<SpriteRenderer>();

        sprite.sortingOrder=Random.Range(-4,-9);

        speed=Random.Range(0.15f,0.28f);

        transform.Rotate(0,0,Random.Range(-90,90));
        transform.localScale*=Random.Range(0.25f,1.5f);
    }

    void Update(){
        transform.position=Vector3.MoveTowards(transform.position, transform.position-new Vector3(0,10,0),0.1f*speed);
    }
}
