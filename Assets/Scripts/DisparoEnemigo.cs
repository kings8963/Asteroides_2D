
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    private float velocidad = 5f;
    private Vector2 direccionDisparo;

    private void Start()
    {
        this.direccionDisparo = (GameObject.FindObjectOfType<ControlesNave>().transform.position - this.transform.position).normalized;
    }

    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddForce(this.direccionDisparo * this.velocidad    );
    }

    private void OnTriggerEnter2D(Collider2D colliderAjeno)
    {
        if (colliderAjeno.gameObject.GetComponent<ControlesNave>() != null)
        {
            Destroy(this.gameObject);
            colliderAjeno.gameObject.GetComponent<ControlesNave>().DestruirNave();
        }
        else
        {
            if (colliderAjeno.gameObject.GetComponent<DetectorPantalla>() != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
