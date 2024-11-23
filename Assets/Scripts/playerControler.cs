using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] public float vida;
    public float vidaMaxima = 100f;
    public event EventHandler MuerteJugador;
    public float velocidad = 5f;
    public Slider barraVida;
    public float fuerzaSalto = 10f;
    [SerializeField] private AudioClip saltoSonido;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;
    [SerializeField] private float tiempoPerdidaControl;
    private bool enSuelo;
    private bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote = new Vector2(2f, 5f);
    private Rigidbody2D rb;
    public Animator animator;
    public Color colorOriginal;
    private SpriteRenderer spriteRenderer;  
    private bool dentroDelFuego = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (barraVida == null)
        {
            barraVida = GameObject.FindObjectOfType<Slider>(); // Busca un slider en la escena
            if (barraVida == null)
            {
                Debug.LogError("No se encontró ninguna barra de vida en la escena.");
            }
            else
            {
                Debug.Log("Barra de vida asignada automáticamente: " + barraVida.gameObject.name);
            }
        }
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            colorOriginal = spriteRenderer.color;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer no encontrado en el GameObject.");
        }
    }

    void Update()
    {
        if (vida <= 1)
        {
            Debug.Log("El jugador ha muerto. Evento MuerteJugador invocado.");
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            SceneManager.LoadScene("menuGameOver");

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
            ControladorSonido.Instance.EjecutarSonido(saltoSonido);
        }

        animator.SetBool("ensuelo", enSuelo);
    }

    IEnumerator DesactivarJugadorConRetraso()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            CambiarColorRojoTemporalmente();
            TomarDaño(15, collision.transform.position);
        }
        if (collision.gameObject.CompareTag("Bala"))
        {
            TomarDañoPorDisparo(20);
            CambiarColorRojoTemporalmente();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Limite"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("menuGameOver");
        }
    }

    public void TomarDaño(float daño, Vector2 posicion)
    {
        vida -= daño;
        if (vida > 0)
        {
            Rebote(posicion);
        }
        else if (vida < 1)
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
        }
    }

    public void TomarDañoPorDisparo(float daño)
    {
        vida -= daño;
        if (vida < 1)
        {
              Physics2D.IgnoreLayerCollision(6, 7, true);
        }
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        rb.velocity = new Vector2(-velocidadRebote.x * (transform.position.x - puntoGolpe.x), velocidadRebote.y);
    }

    public void CambiarColorRojoTemporalmente()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            Invoke("RestaurarColorOriginal", 0.2f);
        }
    }

    public void RestaurarColorOriginal()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = colorOriginal;
        }
    }
    
}
