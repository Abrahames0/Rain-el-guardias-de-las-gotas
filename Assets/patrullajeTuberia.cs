using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullajeTuberia : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool movimientoDerecha;

    public float daño = 10f; // Cantidad de vida que se quita al jugador
    public float tiempoEntreDaños = 1.0f; // Tiempo de espera entre cada daño

    private bool puedeHacerDaño = true; // Controla si el enemigo puede hacer daño
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if (informacionSuelo == false)
        {
            // Girar
            Girar();
        }
    }

    private void Girar()
    {
        movimientoDerecha = !movimientoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && puedeHacerDaño)
        {
            StartCoroutine(DañarJugador(collision.gameObject));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && puedeHacerDaño)
        {
            StartCoroutine(DañarJugador(collision.gameObject));
        }
    }

    // Corutina para aplicar el daño con un intervalo de tiempo
    IEnumerator DañarJugador(GameObject jugador)
    {
        puedeHacerDaño = false;

        // Accede al script del jugador para disminuir su vida
        NewBehaviourScript scriptJugador = jugador.GetComponent<NewBehaviourScript>();
        if (scriptJugador != null)
        {
            scriptJugador.TomarDaño(daño, transform.position); // Llamada a la función TomarDaño
            Debug.Log("Vida del jugador: " + scriptJugador.vida);
        }

        // Espera antes de volver a hacer daño
        yield return new WaitForSeconds(tiempoEntreDaños);
        puedeHacerDaño = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
    }
}
