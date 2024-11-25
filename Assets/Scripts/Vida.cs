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
                jugador.RecuperarVida(cantidadRecuperacion); // Recupera vida
                Debug.Log($"El jugador recuperó {cantidadRecuperacion} de vida.");
                Destroy(gameObject); // Elimina el objeto de vida tras recogerlo
            }
        }
    }
}
