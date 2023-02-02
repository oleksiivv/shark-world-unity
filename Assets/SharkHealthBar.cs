using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public SharkUI ui;

    [HideInInspector]
    public static bool alive=true;
    public SpriteRenderer sprite;
    public SharkFX fx;
    public SharkAudioEffects audio;
    // public Rigidbody2D rb;
    // public Animator animator;

    void Start(){
        healthSlider.value=100;

        alive=true;
    }


    public void receiveDamage(int n=1){
        if(alive)healthSlider.value-=n;

        if(healthSlider.value<=0){
            alive=false;
            ui.showDeathPanel();
            sprite.enabled=false;

            fx.playDeath();
            audio.playDeath();
            //animator.enabled=false;
            //rb.gravityScale=1;
            //rb.AddForce(Vector3.down*100);
        }
    }

    public void heal(int n=1){
        if(!alive)return;

        if(healthSlider.value<100){
            healthSlider.value+=n;
        }

        if(healthSlider.value>100){
            healthSlider.value=100;
        }
    }
}
