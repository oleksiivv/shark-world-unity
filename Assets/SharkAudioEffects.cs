using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAudioEffects : MonoBehaviour
{
    public AudioSource source;
    public AudioClip coin, death, attack, itemGet;

    public void playCoinGet(){
        source.enabled=false;
        source.clip=coin;
        source.enabled=PlayerPrefs.GetInt("!sound")==0;
        source.Play();
    }


    public void playDeath(){
        source.enabled=false;
        source.clip=death;
        source.enabled=PlayerPrefs.GetInt("!sound")==0;
        source.Play();
    }

    private bool attackCanBePlayed=true;
    public void playAttack(){
        
        if(attackCanBePlayed){
            attackCanBePlayed=false;
            source.enabled=false;
            source.clip=attack;
            source.enabled=PlayerPrefs.GetInt("!sound")==0;
            source.Play();
            Invoke(nameof(stopPlayAttack),1f);

        }

        
    }

    public void playItemGet(){
        source.enabled=false;
        source.clip=itemGet;
        source.enabled=PlayerPrefs.GetInt("!sound")==0;
        source.Play();
    }

    void stopPlayAttack(){
        attackCanBePlayed=true;
    }
}
