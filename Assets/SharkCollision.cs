using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkCollision : MonoBehaviour
{
    public SharkFX fx;
    public SharkScore score;
    public SharkHealthBar health;

    public CoinsController coins;
    public SharkAudioEffects audio;
    public GameObject starImage;
    

    void Start(){
        StarX2.x=1;
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if(!SharkHealthBar.alive)return;

        if(other.gameObject.tag=="fish"){
            fx.playDamage();
            score.changeScore(StarX2.x);
            health.receiveDamage(1);
            audio.playAttack();

            Destroy(other.gameObject);

        }
        if(other.gameObject.tag=="heart"){
            fx.playGetHeart();
            health.heal(5*StarX2.x);
            audio.playItemGet();

            Destroy(other.gameObject);
        }

        if(other.gameObject.tag=="Coin"){
            fx.playGetCoin();
            coins.updateCoinsValue(5*StarX2.x);
            audio.playCoinGet();

            Destroy(other.gameObject);
        }

        if(other.gameObject.tag=="star"){
            StarX2.x=2;
            fx.playGetCoin();
            starImage.SetActive(true);

            if(IsInvoking(nameof(cleanX2))){
                CancelInvoke(nameof(cleanX2));
            }

            Invoke(nameof(cleanX2), 10f);

            Destroy(other.gameObject);
        }

    }

    MediumEnemy enemy;
    void OnTriggerStay2D(Collider2D other){

        if(!SharkHealthBar.alive && enemy==null)return;

        if(other.gameObject.tag=="mediumEnemy"){
            //if(PlayerPrefs.GetInt("currentShark",0)==0){

                
                
                int level=PlayerPrefs.GetInt("current",0);
                Debug.Log("Current Shark: "+level.ToString());

                if(enemy==null)enemy=other.gameObject.GetComponent<MediumEnemy>();

                if(enemy.health>0){
                    switch(level){
                        case 0:
                        health.receiveDamage(2);
                        break;

                        case 1:
                        health.receiveDamage(2);
                        break;

                        case 2:
                        health.receiveDamage(1);
                        break;

                        case 3: 
                        health.receiveDamage(1);
                        break;

                        default:
                        health.receiveDamage(1);
                        break;

                    }
                    
                    //health.receiveDamage(PlayerPrefs.GetInt("currentShark",0)==0?2:1);
                }
                
                switch(level){
                    case 0:
                        enemy.receiveDamage(0.25f);
                        break;

                    case 1:
                        enemy.receiveDamage(0.3f);
                        break;

                    case 2:
                        enemy.receiveDamage(0.35f);
                        break;

                    case 3: 
                        enemy.receiveDamage(0.45f);
                        break;

                    default:
                        enemy.receiveDamage(0.65f);
                        break;

                }

                //enemy.receiveDamage(PlayerPrefs.GetInt("currentShark",0)==0?0.25f:0.5f);
                enemy.speed=0;

                if(!SharkHealthBar.alive){
                    enemy.speed=1;
                    enemy=null;
                }

                if(enemy!=null){
                    if(enemy.health==0){
                        //Destroy(enemy.gameObject);

                        fx.playDamage();
                        score.changeScore((int)(20f*(21f-enemy.level)));
                    }
                }
            //}
        }
    }

    void OnTriggerExit2D(Collider2D other){

        if(!SharkHealthBar.alive)return;

        if(other.gameObject.tag=="mediumEnemy"){
            if(PlayerPrefs.GetInt("currentShark",0)==0){
              health.receiveDamage(PlayerPrefs.GetInt("currentShark",0)==0?2:1);
                if(enemy!=null){
                    enemy.speed=0.75f;
                }
            }
        }
    }

    void cleanX2(){
        StarX2.x=1;
        starImage.SetActive(false);
    }
}
