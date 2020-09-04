using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    private float velocidad = 15f;
    void Update()
    {
        this.transform.Translate(Vector2.up * Time.deltaTime * this.velocidad, Space.Self); 
    }

    private void OnTriggerEnter2D(Collider2D colliderAjeno)
    {
        if (colliderAjeno.gameObject.GetComponent<Asteroide>() != null)
        {
            Destroy(this.gameObject);
            colliderAjeno.gameObject.GetComponent<Asteroide>().Destruir();  
        }
        else
        {
            if (colliderAjeno.gameObject.GetComponent<Ovni>() != null)
            {
                Destroy(this.gameObject);
                colliderAjeno.gameObject.GetComponent<Ovni>().DestruirOvni();
            }


            if (colliderAjeno.gameObject.GetComponent<DetectorPantalla>() != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
