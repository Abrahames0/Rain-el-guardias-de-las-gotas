/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    [SerializeField] private float dañoPorSegundo = 10f;  // Daño que el fuego inflige al jugador cada segundo

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NewBehaviourScript jugador = other.GetComponent<NewBehaviourScript>();
            if (jugador != null)
            {
                jugador.CambiarColorRojoTemporalmente();  // Cambia el color al entrar en el fuego
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NewBehaviourScript jugador = other.GetComponent<NewBehaviourScript>();
            if (jugador != null)
            {
                // Aplica daño constante mientras el jugador esté en el fuego
                jugador.TomarDaño(dañoPorSegundo * Time.deltaTime, transform.position);
                jugador.CambiarColorRojoTemporalmente();  // Mantiene el color rojo mientras esté dentro del fuego
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NewBehaviourScript jugador = other.GetComponent<NewBehaviourScript>();
            if (jugador != null)
            {
                jugador.RestaurarColorOriginal();  // Restaura el color al salir del fuego
            }
        }
    }
}
 */