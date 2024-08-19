using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> sprites;

    void Start()
    {
        int random = Random.Range(0, sprites.Count);
        sr.sprite = sprites[random];
    }


}
