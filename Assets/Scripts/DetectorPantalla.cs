using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorPantalla : MonoBehaviour
{

    [SerializeField] private bool esVertical;

    private void OnTriggerEnter2D(Collider2D colliderAjeno)
    {
        if (this.esVertical)
        {
            // Debug.Log("Colision");

            float posicionDestino = -colliderAjeno.transform.position.y;
            if (posicionDestino > 0f)
            {
                posicionDestino = posicionDestino - 0.25f;
            }

            else
            {
                posicionDestino = posicionDestino + 0.25f;
            }
            colliderAjeno.transform.position = new Vector2(colliderAjeno.transform.position.x, posicionDestino);
        }

        else
        {
            float posicionDestino = -colliderAjeno.transform.position.x;
            if (posicionDestino > 0f)
            {
                posicionDestino = posicionDestino - 0.25f;
            }

            else
            {
                posicionDestino = posicionDestino + 0.25f;
            }
          //  colliderAjeno.transform.position = new Vector2(colliderAjeno.transform.position.x, posicionDestino);
            colliderAjeno.transform.position = new Vector2(posicionDestino, colliderAjeno.transform.position.y);
        }
        
    }
}
