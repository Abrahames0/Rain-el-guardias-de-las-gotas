using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    // [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool movimientoDerecha;
    [SerializeField] private float danoAlJugador;  // Daño que el enemigo inflige al jugador
    [SerializeField] private AudioClip sonidoDaño; 

    private void Update()
    {
        // Movimiento del enemigo utilizando Raycast para detectar el suelo
        // RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        // if (!informacionSuelo)
        // {
        //     // Girar enemigo si no hay suelo
        //     Girar();
        // }
        
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
                // Cambia el color del jugador al recibir daño
                jugador.CambiarColorRojoTemporalmente();
                jugador.TomarDaño(danoAlJugador, transform.position);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NewBehaviourScript jugador = other.gameObject.GetComponent<NewBehaviourScript>();
            if (jugador != null)
            {
                // Aplica daño continuo mientras el jugador esté en contacto con el fuego
                jugador.TomarDaño(danoAlJugador * Time.deltaTime, transform.position);
                jugador.CambiarColorRojoTemporalmente();
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

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(controladorSuelo.position, controladorSuelo.position + Vector3.down * distancia);
    // }
}
