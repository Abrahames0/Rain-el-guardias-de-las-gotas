using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform player; // El objeto del personaje
    public float parallaxStrength = 0.1f; // Ajusta la fuerza del parallax (menor valor = menos movimiento)
    private Vector3 initialPosition;

    void Start()
    {
        // Guardar la posición inicial del fondo
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calcula la nueva posición de la imagen de fondo según la posición del personaje
        Vector3 parallaxPosition = initialPosition + (player.position * parallaxStrength);
        parallaxPosition.z = initialPosition.z; // Mantiene la profundidad inicial del fondo

        // Aplica la nueva posición al fondo
        transform.position = parallaxPosition;
    }
}
