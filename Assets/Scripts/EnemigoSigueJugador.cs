using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSigueJugador : MonoBehaviour
{
    private Transform player; // Transform del jugador
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float followRange = 10f; // Distancia máxima para empezar a seguir al jugador
    [SerializeField] private float danoAlJugador; // Daño que el enemigo inflige al jugador
    [SerializeField] private AudioClip sonidoDaño;

    private void Update()
    {
        if (player == null) return;

        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango, el enemigo lo sigue
        if (distanceToPlayer <= followRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void AsignarJugador(Transform jugadorTransform)
    {
        player = jugadorTransform;
        Debug.Log("Jugador asignado al enemigo: " + jugadorTransform.name);
    }

    private void OnCollisionEnter2D(Collision2D other)
{
    // Verifica si el objeto con el que colisionó tiene la etiqueta "Player"
    if (other.gameObject.CompareTag("Player"))
    {
        // Intenta acceder al script del jugador
        NewBehaviourScript jugador = other.gameObject.GetComponent<NewBehaviourScript>();
        if (jugador != null)
        {
            // Inflige daño al jugador y cambia su color para indicar el golpe
            Debug.Log("El enemigo golpeó al jugador.");
            jugador.CambiarColorRojoTemporalmente();
            jugador.TomarDaño(danoAlJugador, transform.position);
            ControladorSonido.Instance.EjecutarSonido(sonidoDaño);
        }
        else
        {
            Debug.LogError("El script 'NewBehaviourScript' no se encontró en el jugador.");
        }
    }
}

}
