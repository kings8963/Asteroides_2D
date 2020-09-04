using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorUI : MonoBehaviour
{
    public void ActualizarInterfaz() 
    {
        this.transform.Find("txtPuntaje").GetComponent<TextMeshProUGUI>().text = GameObject.FindObjectOfType<ControladorDeJuego>().ObtenerPuntosActuales().ToString();
        int vidasRestantes = GameObject.FindObjectOfType<ControladorDeJuego>().ObtenerVidasRestantes();

        if (vidasRestantes < 3 )
        {
            this.transform.Find("Vida_3").gameObject.SetActive(false);
        }
        if (vidasRestantes < 2)
        {
            this.transform.Find("Vida_2").gameObject.SetActive(false);
        }
        if (vidasRestantes < 1)
        {
            this.transform.Find("Vida_1").gameObject.SetActive(false);
        }
    }

    public void MostrarPanelFinDelJuego()
    {
        this.transform.Find("VentanaFin").transform.Find("txtRanking").GetComponent<TextMeshProUGUI>().text = "";

        for (int i = 1; i <= 10; i++  )
        {
            string textoAnterior = this.transform.Find("VentanaFin").transform.Find("txtRanking").GetComponent<TextMeshProUGUI>().text;
            this.transform.Find("VentanaFin").transform.Find("txtRanking").GetComponent<TextMeshProUGUI>().text = textoAnterior +  "\n" + i + "." + PlayerPrefs.GetInt("top" + i, 0).ToString();
        }
       
        this.transform.Find("VentanaFin").gameObject.SetActive(true);
    }
}
