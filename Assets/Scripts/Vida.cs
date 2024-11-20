using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float cantidadRecuperacion = 20f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NewBehaviourScript jugador = other.GetComponent<NewBehaviourScript>();
            if (jugador != null)
            {
                // jugador.RecuperarVida(cantidadRecuperacion);
                Destroy(gameObject);
            }
        }
    }
}
