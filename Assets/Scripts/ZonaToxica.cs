using System.Collections;
using UnityEngine;

public class ZonaToxica : MonoBehaviour
{
    public float dañoPorSegundo = 10f; // Daño continuo que se aplica por segundo
    private bool jugadorDentro = false;
    private NewBehaviourScript jugador;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugador = other.GetComponent<NewBehaviourScript>();
            if (jugador != null)
            {
                jugadorDentro = true;
                // StartCoroutine(AplicarDañoContinuo());
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
            // StopCoroutine(AplicarDañoContinuo());
        }
    }

    // IEnumerator AplicarDañoContinuo()
    // {
    //     while (jugadorDentro)
    //     {
    //         jugador.TomarDañoContinuo(dañoPorSegundo * Time.deltaTime);
    //         yield return null; // Espera un frame antes de continuar
    //     }
    // }
}
