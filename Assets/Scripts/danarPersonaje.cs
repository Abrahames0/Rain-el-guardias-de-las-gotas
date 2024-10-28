/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool movimientoDerecha;
    [SerializeField] private float dañoAlJugador = 10f;  // Daño que el enemigo inflige al jugador

    private void Update()
    {
        // Movimiento del enemigo utilizando Raycast para detectar el suelo
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        if (!informacionSuelo)
        {
            // Girar enemigo si no hay suelo
            Girar();
        }
        
        // Movimiento constante del enemigo
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void Girar()
    {
        movimientoDerecha = !movimientoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Accede al script del jugador para aplicarle daño
            NewBehaviourScript jugador = other.gameObject.GetComponent<NewBehaviourScript>();
            if (jugador != null)
            {
                // Llama al método TomarDaño pasando el daño y la posición del enemigo
                jugador.TomarDaño(dañoAlJugador, transform.position);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.position, controladorSuelo.position + Vector3.down * distancia);
    }
}
 */