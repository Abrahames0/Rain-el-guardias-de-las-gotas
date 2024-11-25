using UnityEngine;

public class SeguirEnemigoSol : MonoBehaviour
{
    private Transform player; // Transform del jugador
    public float speed = 3f; // Velocidad de movimiento
    public float stopDistance = 2f; // Distancia mínima al jugador

    void Start()
    {
        BuscarJugador();
    }

    void Update()
    {
        if (player == null)
        {
            BuscarJugador(); // Buscar al jugador si aún no está asignado
            return;
        }

        // Calcular la distancia al jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Moverse hacia el jugador si está fuera de la distancia mínima
        if (distanceToPlayer > stopDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    public void AsignarJugador(Transform jugadorTransform)
    {
        player = jugadorTransform;
        Debug.Log("Jugador asignado al enemigo Sol: " + jugadorTransform.name);
    }

    private void BuscarJugador()
    {
        // Buscar al jugador por la etiqueta "Player"
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            player = jugador.transform;
            Debug.Log("Jugador asignado al enemigo Sol: " + jugador.name);
        }
        else
        {
            Debug.LogWarning("No se encontró un jugador con la etiqueta 'Player'.");
        }
    }
}
