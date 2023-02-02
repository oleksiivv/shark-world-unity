using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MediumEnemy : Fish{

    public float health=100f;
    public float level=1;

    [Header("Child 0, Child 1, Child 2")]
    private ParticleSystem runEffect, damageEffect, deathEffect;
    private TextMeshPro healthVal;

    private SpriteRenderer sprite;
    private BoxCollider2D collider;

    void Start(){
        speed=0.75f;

        runEffect=gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        damageEffect=gameObject.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        deathEffect=gameObject.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();

        healthVal=gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshPro>();
        healthVal.text=health.ToString()+"%";

        sprite=gameObject.GetComponent<SpriteRenderer>();
        collider=gameObject.GetComponent<BoxCollider2D>();

        runEffect.Play();
    }

    public void receiveDamage(float n){
        health-=n*level;
        healthVal.text=health.ToString()+"%";

        if(health<=0){
            sprite.enabled=false;
            collider.enabled=false;
            deathEffect.Play();
            healthVal.gameObject.SetActive(false);
            
            Invoke(nameof(clean),1f);
        }
        else{
            damageEffect.Play();
        }
    }

    void clean(){
        Destroy(gameObject);
    }


    
}
