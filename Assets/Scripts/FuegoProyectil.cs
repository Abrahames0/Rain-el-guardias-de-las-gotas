using UnityEngine;

public class FuegoProyectil : MonoBehaviour
{
    public float speed = 2f; // Velocidad del proyectil
    // Daño que inflige el proyectil
    private Transform target;
    public float daño = 0f;
     [SerializeField] private AudioClip dañoPersonaje;  // Referencia al jugador

    void Start()
    {
        // Encuentra al jugador en la escena por etiqueta
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'Player'");
        }
    }

    void Update()
    {
        if (target == null) return;

        // Mover el proyectil hacia el jugador
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Rotar el proyectil para que apunte hacia el jugador (opcional)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

 private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.TryGetComponent(out NewBehaviourScript playerControler))
        {
            
            playerControler.TomarDañoPorDisparo(daño);  
            ControladorSonido.Instance.EjecutarSonido(dañoPersonaje); 
            Destroy(gameObject);

        }
    
    }   
}

