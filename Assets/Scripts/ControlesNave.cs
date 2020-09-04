
using UnityEngine;

public class ControlesNave : MonoBehaviour
{
    private float velocidadDeGiro = 100f;
    private float fuerzadepropulsion = 2f;
    [SerializeField] private GameObject prefabDisparo;
    [SerializeField] private GameObject prefabExplosion;
    [SerializeField] private GameObject efectoPropulsor;
    private float cadenciaDeDisparo = 0.5f;
    private float esperaDeDisparo = 0f;


    //sonidos
    [SerializeField] private AudioClip sfxDisparo;
    [SerializeField] private AudioClip sfxExplosion;


    public void Update()
    {
        this.ManejarRotacion();
        this.ManejarPropulsion();
        this.ManejarDisparos();
    }

    private void ManejarDisparos()
    {
        float disparar = Input.GetAxis("Fire1");

        if (disparar > 0f && this.PuedeDisparar())
        {
            this.Disparar();
        }
    }

    private bool PuedeDisparar()
    {
        return Time.time > this.esperaDeDisparo;
    }

    private void Disparar()
    {
        GameObject.Instantiate(this.prefabDisparo, this.transform.position, this.transform.rotation);
        this.esperaDeDisparo = Time.time + this.cadenciaDeDisparo;
        this.GetComponent<AudioSource>().PlayOneShot(this.sfxDisparo);
    }

    private void ManejarRotacion()
    {
        float giro = -Input.GetAxis("Horizontal");
        this.transform.Rotate(0f, 0f, giro * Time.deltaTime * this.velocidadDeGiro);
    }

    private void ManejarPropulsion()
    {
        float propulsion = Input.GetAxis("Vertical");
        if (propulsion > 0f)
        {
            this.efectoPropulsor.SetActive(true);
            this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, propulsion * this.fuerzadepropulsion));
        }

        else
        {
            this.efectoPropulsor.SetActive(false);     
        }
        
    
    }

    public void DestruirNave()
    {
        Instantiate(this.prefabExplosion, this.transform.position, Quaternion.identity);
        this.GetComponent<AudioSource>().PlayOneShot(this.sfxExplosion);
        if (GameObject.FindObjectOfType<ControladorDeJuego>().PerderVida())
        {
            this.transform.position = new Vector2(0f, 0f);
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

        }

        else
        {
            this.gameObject.SetActive(false);
        }
    }



}

    
