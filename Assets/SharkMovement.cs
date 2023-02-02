using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkMovement : MonoBehaviour
{
    public Vector2 border;
    public Slider moveSlider;

    private float acceleration;
    public static float speed=1;
    public SharkHealthBar health;
    public int startDeg=0;

    void Start(){
        acceleration=0.1f;
        speed=1;

        
    }

    void Update(){
        if(speed==0 || !SharkHealthBar.alive)return;

        if(Input.GetMouseButtonUp(0)){
            moveSlider.value=0;
        }
        else{
            if(acceleration<1)acceleration+=0.0001f*SharkMovement.speed;
        }

        if(Mathf.Abs(moveSlider.value)<0.1f){
            acceleration=0.1f;
        }


        if(speed<2)speed+=0.001f;
        else if(speed>=2 && speed<3)speed+=0.00008f;
        else speed+=0.00002f;


        if((gameObject.transform.position.x<=border.y && moveSlider.value >=0) || (gameObject.transform.position.x>=border.x && moveSlider.value <=0)){
            gameObject.transform.position+=new Vector3(moveSlider.value/2,0,0)*acceleration;
            transform.eulerAngles=new Vector3(0,0,startDeg-moveSlider.value*60);
        }
        // else{
        //     moveSlider.value=0;
        //     transform.eulerAngles=new Vector3(0,0,-moveSlider.value*60);
        // }

        //gameObject.transform.position=new Vector3(moveSlider.value,0,0)*2.5f;
        //transform.eulerAngles=new Vector3(0,0,-moveSlider.value*10);

        
    }
}
