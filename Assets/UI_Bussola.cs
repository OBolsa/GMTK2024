using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Bussola : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform gameObjectTarget;  // O destino para onde a bússola deve apontar
    public RectTransform compassArrow;  // O RectTransform da seta da bússola (UI)
    public Canvas canvas_InGame;
    public GameObject Player;
    private Vector2 screenPoint, screenPointTarget;
    private float angle;
    private  Vector2 canvasPos;
    private Vector3 midpoint;
    public Vector3 offsetTarget;
    public Vector2 offsetTela;
    public float offsetArrow;

    void Start()
    {
        
    }

     void Update()
    {
        PointAndClampToScreen();
    }

    void PointAndClampToScreen()
    {
        //Angulação 
        Vector2 direction = gameObjectTarget.position - Player.transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        compassArrow.rotation = Quaternion.Euler(0, 0, angle);
        
        //Posição Media
        midpoint = (gameObjectTarget.position + Player.transform.position) / 2;
        screenPoint = Camera.main.WorldToViewportPoint(midpoint);
        screenPointTarget = (Vector2)Camera.main.WorldToViewportPoint(gameObjectTarget.position);

        if( Vector2.Distance(screenPoint,screenPointTarget)<=offsetArrow)
        {
        compassArrow.rotation = Quaternion.Euler(0, 0, -90f);

        // Converte a posição da tela para coordenadas do Canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle
        (
            canvas_InGame.GetComponent<RectTransform>(), 
            Camera.main.ViewportToScreenPoint(screenPointTarget), 
            canvas_InGame.worldCamera, 
            out canvasPos
        );
        // Define a posição da seta
        compassArrow.localPosition = canvasPos;
        }

        else
        {

        compassArrow.rotation = Quaternion.Euler(0, 0, angle);
        // Clampa a posição da seta na borda da tela
        screenPoint.x = Mathf.Clamp(screenPoint.x,offsetTela.x,offsetTela.y);
        screenPoint.y = Mathf.Clamp(screenPoint.y,offsetTela.x,offsetTela.y);

        // Converte a posição da tela para coordenadas do Canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle
        (
            canvas_InGame.GetComponent<RectTransform>(), 
            Camera.main.ViewportToScreenPoint(screenPoint), 
            canvas_InGame.worldCamera, 
            out canvasPos
        );
        // Define a posição da seta
        compassArrow.localPosition = canvasPos;
        }
    }
}
