using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroide : MonoBehaviour
{
    // Start is called before the first frame update

    private float velocidad = 0.9f;
    private Vector2 direccionMovimiento;
    private float velocidadDeRotacion;
    [SerializeField] private Tipo_Asteroide tipo;
    //prefabs asteroides
    [SerializeField] private GameObject prefabAsteroideP;
    [SerializeField] private GameObject prefabAsteroideM;
    [SerializeField] private GameObject prefabAsteroideG;
    [SerializeField] private GameObject prefabDestruccion;

    

    private void Start()
    {
        this.direccionMovimiento = Random.insideUnitCircle.normalized;
        this.velocidadDeRotacion = Random.Range(30f, 60f);
    }

    private void Update()
    {
        this.MoverAsteriode();
        this.RotarAsteroide();
    }

    private void RotarAsteroide()
    {
        this.transform.Rotate(0f, 0f, this.velocidadDeRotacion * Time.deltaTime, Space.Self);
    }

    private void MoverAsteriode()
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

    public void Destruir()
    {
   

        if (this.tipo == Tipo_Asteroide.GRANDE)
        {
            Instantiate(this.prefabAsteroideM, this.transform.position, Quaternion.identity);
            Instantiate(this.prefabAsteroideM, this.transform.position, Quaternion.identity);
            GameObject.FindObjectOfType<ControladorDeJuego>().sumarPuntos(20);
        }

        else
        {
            if (this.tipo == Tipo_Asteroide.MEDIANO)
            {
                Instantiate(this.prefabAsteroideP, this.transform.position, Quaternion.identity);
                Instantiate(this.prefabAsteroideP, this.transform.position, Quaternion.identity);
                GameObject.FindObjectOfType<ControladorDeJuego>().sumarPuntos(15);
            }

            else
            {
                GameObject.FindObjectOfType<CreadorDeAmenazas>().CrearAmenaza();
                GameObject.FindObjectOfType<ControladorDeJuego>().sumarPuntos(10);
            }
            
            Instantiate(this.prefabDestruccion, this.transform.position, Quaternion.identity);
            GameObject.FindObjectOfType<ControladorDeJuego>().sonidoAsteroide();
            Destroy(this.gameObject);
            

        }

    }
}
