using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] public float vida;

    public event EventHandler MuerteJugador;

    public float velocidad = 5f;
    public Slider barraVida;
    public float fuerzaSalto = 10f;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;

    [SerializeField] private float tiempoPerdidaControl;

    private bool enSuelo;
    private bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote = new Vector2(2f, 5f); // Menos fuerza de rebote
    private Rigidbody2D rb;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (barraVida != null)
        {
            Debug.Log("Barra de vida asignada: " + barraVida.gameObject.name);
        }
        else
        {
            Debug.LogError("La barra de vida no está asignada.");
        }
    }

    void Update()
    {
        if (vida <= 1)
        {
            Debug.Log("El jugador ha muerto. Evento MuerteJugador invocado.");
            MuerteJugador?.Invoke(this, EventArgs.Empty);

            // Espera un segundo antes de desactivar el jugador
            StartCoroutine(DesactivarJugadorConRetraso());
        }

        if (barraVida != null)
        {
            barraVida.value = vida;
        }
        else
        {
            Debug.LogError("La barra de vida no está asignada.");
        }

        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

        animator.SetFloat("movement", velocidadX * velocidad);

        if (velocidadX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (velocidadX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector3 posicion = transform.position;
        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        enSuelo = hit.collider != null;

        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }

        animator.SetBool("ensuelo", enSuelo);
    }

    IEnumerator DesactivarJugadorConRetraso()
    {
        // Espera un segundo antes de desactivar el jugador para asegurar que el evento se maneje correctamente
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);  // Desactiva el jugador
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            TomarDaño(15, collision.transform.position);
        }
    }

    public void TomarDaño(float daño, Vector2 posicion)
    {
        vida -= daño;
        if (vida > 0)
        {
            Rebote(posicion); // Llama a la función de rebote al recibir daño
        }
        else
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
        }
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        rb.velocity = new Vector2(-velocidadRebote.x * (transform.position.x - puntoGolpe.x), velocidadRebote.y); // Reduce la cantidad de rebote
    }
}