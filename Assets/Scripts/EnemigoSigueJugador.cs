using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSigueJugador : MonoBehaviour
{
     public Transform player; // Asigna aquí el Transform del jugador desde el inspector
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float followRange = 10f;
    [SerializeField] private float danoAlJugador;  // Daño que el enemigo inflige al jugador
    [SerializeField] private AudioClip sonidoDaño; // Distancia máxima para empezar a seguir al jugador

    private void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango, el enemigo lo sigue
        if (distanceToPlayer <= followRange)
        {
            // Calcula la dirección hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;

            // Mueve al enemigo hacia el jugador
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el rango de seguimiento en la escena para facilitar el ajuste
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Accede al script del jugador para aplicarle daño
            NewBehaviourScript jugador = other.gameObject.GetComponent<NewBehaviourScript>();
            if (jugador != null)
            {
                // Cambia el color del jugador al recibir daño
                jugador.CambiarColorRojoTemporalmente();
                jugador.TomarDaño(danoAlJugador, transform.position);
                ControladorSonido.Instance.EjecutarSonido(sonidoDaño);
            }
        }
    }

     private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Restaura el color original cuando el jugador sale del fuego
            NewBehaviourScript jugador = other.gameObject.GetComponent<NewBehaviourScript>();
            if (jugador != null)
            {
                jugador.RestaurarColorOriginal();
            }
        }
    }  
}
