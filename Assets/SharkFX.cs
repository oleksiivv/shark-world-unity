using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkFX : MonoBehaviour
{
    public ParticleSystem runEffect, damageEffect, getHeart, deathEffect, coinGetEffect;


    public void playDamage(){
        damageEffect.Play();
    }

    public void playGetHeart(){
        getHeart.Play();
    }

    public void playDeath(){
        runEffect.gameObject.SetActive(false);
        damageEffect.gameObject.SetActive(false);
        getHeart.gameObject.SetActive(false);
        coinGetEffect.gameObject.SetActive(false);

        deathEffect.Play();
    }

    public void playGetCoin(){
        coinGetEffect.Play();
    }
}
