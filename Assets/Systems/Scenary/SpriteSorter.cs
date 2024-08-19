using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> sprites;
    public float valorDesvio;
    public bool gerarDesvio = false;

    void Start()
    {
        int random = Random.Range(0, sprites.Count);
        sr.sprite = sprites[random];
        if(gerarDesvio)GeneratePosiçãoRandomValue(valorDesvio);
    }
    public void GeneratePosiçãoRandomValue(float random)
    {
        
        float posicaoX = Random.Range(-random, random);
        float posicaoY = Random.Range(-random, random);
        Vector3 addPossicao = new Vector3(posicaoX,posicaoY,0f); 
        this.transform.position += addPossicao;

        Debug.Log("addPossicao" + addPossicao);
    }

}
