using UnityEngine;

public class SeguirEnemigoSol : MonoBehaviour
{
    public Transform player; // Asigna el jugador desde el Inspector
    public float speed = 3f; // Velocidad de movimiento
    public float stopDistance = 2f; // Distancia mínima al jugador

    void Update()
    {
        if (player == null) return;

        // Calcular la distancia al jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Moverse hacia el jugador si está fuera de la distancia mínima
        if (distanceToPlayer > stopDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }
}
