using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeJuego : MonoBehaviour
{
    private int vidasMaximas = 3;
    private int vidasRestantes;
    private int puntaje = 0;
    //sonidos
    [SerializeField] private AudioClip sfxDestruccionAsteroide;
    [SerializeField] private AudioClip sfxDestruirOvni;

    private void Start()
    {
        this.vidasRestantes = this.vidasMaximas;

    }

    public bool PerderVida()
    {
        this.vidasRestantes--;
        GameObject.FindObjectOfType<ControladorUI>().ActualizarInterfaz();

        if (this.vidasRestantes < 0)
        {
            this.PerderJuego();
            return false;
        }

        return true;
    }

    private void PerderJuego()
    {
        Time.timeScale = 0;
        this.ActualizarRanking();
        GameObject.FindObjectOfType<ControladorUI>().ActualizarInterfaz();
        GameObject.FindObjectOfType<ControladorUI>().MostrarPanelFinDelJuego();
    }

    public void sumarPuntos(int cantidad)
    {
        this.puntaje = this.puntaje + cantidad;
        GameObject.FindObjectOfType<ControladorUI>().ActualizarInterfaz();
    }

    public int ObtenerPuntosActuales()
    {
        return this.puntaje;
    }

    public int ObtenerVidasRestantes()
    {
        return this.vidasRestantes;
    }

    public void sonidoAsteroide()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.sfxDestruccionAsteroide);
    }

    public void sonidoOvni()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.sfxDestruirOvni);
    }

    private void ActualizarRanking()
    {

        /* int puntajeMaximo = PlayerPrefs.GetInt("top1", -1);

         if (puntajeMaximo < this.puntaje)
         {
             PlayerPrefs.SetInt("top1", this.puntaje);
         }

         PlayerPrefs.Save();*/
        int posicionComparada = 1;
        bool seguirBuscando = true;
        while (posicionComparada <= 10 && seguirBuscando)
        {
            if (PlayerPrefs.GetInt("top" + posicionComparada, -1) < this.puntaje)
            {
                PlayerPrefs.SetInt("top" + posicionComparada, this.puntaje);
                seguirBuscando = false;
            }
            posicionComparada++; 
        }
    
    }
}   


