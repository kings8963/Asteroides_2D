using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovni : MonoBehaviour
{
    // Start is called before the first frame update

    private float velocidad = 0.9f;
    private Vector2 direccionMovimiento;
    [SerializeField] private GameObject prefabDisparo;
    [SerializeField] private GameObject prefabExplosion;

    private float intervaloEntreDisparos = 3f;
    private float tiempoUltimoDisparo = 0f;

    //sonidos
    [SerializeField] private AudioClip sfxDisparoOvni;
   

    private void Start()
    {
        this.CambiarDireccion();
        this.RandomizarIntervaloDeDisparo();

    }

    private void CambiarDireccion()
    {
        this.direccionMovimiento = Random.insideUnitCircle.normalized;
    }

    private void Update()
    {
        this.MoverOVNI();
        this.ManejarDisparo();

    }

    public void ManejarDisparo()
    {
        if (this.tiempoUltimoDisparo + this.intervaloEntreDisparos <= Time.time)
        {
            this.Disparar();
        }
    }


    private void MoverOVNI()
    {
        this.transform.Translate(this.direccionMovimiento * this.velocidad * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.GetComponent<ControlesNave>() != null)
        {
            colision.gameObject.GetComponent<ControlesNave>().DestruirNave();
        }
    }

    private void Disparar()
    {
        
        GameObject.Instantiate(this.prefabDisparo, this.transform.position, this.transform.rotation);
        this.GetComponent<AudioSource>().PlayOneShot(this.sfxDisparoOvni);
        this.CambiarDireccion();
        this.tiempoUltimoDisparo = Time.time;
        this.RandomizarIntervaloDeDisparo();

    }   

    private void RandomizarIntervaloDeDisparo()
    {
        this.intervaloEntreDisparos = Random.Range(3f, 6f);
    }


    public void DestruirOvni()
    {
        
        Instantiate(this.prefabExplosion, this.transform.position, Quaternion.identity);
        GameObject.FindObjectOfType<ControladorDeJuego>().sonidoOvni();
        GameObject.FindObjectOfType<CreadorDeAmenazas>().CrearAmenaza();
        GameObject.FindObjectOfType<ControladorDeJuego>().sumarPuntos(30);
        Destroy(this.gameObject);
        
    }
}
