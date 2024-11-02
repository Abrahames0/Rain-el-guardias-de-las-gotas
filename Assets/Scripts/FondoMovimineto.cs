using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;
    private Material material;
    private Rigidbody2D jugadorRB;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        jugadorRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Solo mueve el fondo si el jugador tiene velocidad en el eje X
        if (Mathf.Abs(jugadorRB.velocity.x) > 0.1f)
        {
            offset = new Vector2(jugadorRB.velocity.x * velocidadMovimiento.x, jugadorRB.velocity.y * velocidadMovimiento.y) * Time.deltaTime;
            material.mainTextureOffset += offset;
        }
    }
}
