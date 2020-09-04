using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorDeAmenazas : MonoBehaviour
{

    [SerializeField] private GameObject[] prefabsAmenazas;
    public void CrearAmenaza()
    {
        Vector2 posicion = this.transform.GetChild(Random.Range(0, this.transform.childCount)).transform.position;
        Instantiate(this.prefabsAmenazas[Random.Range(0, this.prefabsAmenazas.Length)], posicion, Quaternion.identity);
    }
}
