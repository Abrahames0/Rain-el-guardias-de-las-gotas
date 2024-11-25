using UnityEngine;

public class DisparoEnemigoSol : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se disparan los proyectiles
    private Transform player; // Transform del jugador
    public float shootInterval = 2f; // Tiempo entre disparos
    public float projectileSpeed = 5f; // Velocidad del proyectil

    private float nextShootTime;

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

        // Apuntar hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Disparar si es el momento
        if (Time.time >= nextShootTime)
        {
            Shoot(direction);
            nextShootTime = Time.time + shootInterval;
        }
    }

    public void AsignarJugador(Transform jugadorTransform)
    {
        player = jugadorTransform;
        Debug.Log("Jugador asignado al enemigo Sol (Disparador): " + jugadorTransform.name);
    }

    private void BuscarJugador()
    {
        // Buscar al jugador por la etiqueta "Player"
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            player = jugador.transform;
            Debug.Log("Jugador asignado al enemigo Sol (Disparador): " + jugador.name);
        }
        else
        {
            Debug.LogWarning("No se encontró un jugador con la etiqueta 'Player'.");
        }
    }

    void Shoot(Vector2 direction)
    {
        // Crear el proyectil y darle dirección
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed; // Velocidad del proyectil
        Destroy(projectile, 2f); // Destruir el proyectil después de 2 segundos
    }
}
