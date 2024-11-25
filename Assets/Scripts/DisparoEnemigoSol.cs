using UnityEngine;

public class DisparoEnemigoSol : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se disparan los proyectiles
    public Transform player; // Asigna el jugador desde el Inspector
    public float shootInterval = 2f; // Tiempo entre disparos

    private float nextShootTime;

    void Update()
    {
        if (player == null) return;

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

    void Shoot(Vector2 direction)
    {
        // Crear el proyectil y darle dirección
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 3f; // Velocidad del proyectil
        Destroy(projectile, 2f); // Destruir el proyectil después de 5 segundos
    }
}
