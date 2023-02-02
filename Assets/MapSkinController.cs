using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSkinController : MonoBehaviour
{
    public Sprite[] maps;
    public SpriteRenderer[] sprites;

    int curr;
    void Start()
    {
        curr=PlayerPrefs.GetInt("currentMap",0);
        foreach(var sprite in sprites)sprite.GetComponent<SpriteRenderer>().sprite=maps[curr];
    }

}
