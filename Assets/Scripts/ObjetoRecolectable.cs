using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjetoRecolectable : MonoBehaviour
{
    public static int objetosRecolectados = 0; // Contador de objetos recolectados
    public Text marcadorTexto;                 // Referencia al texto de la UI
    public static int totalObjetos;            // Total de objetos en la escena

    [SerializeField] private AudioClip objetoRecolectado;
    private bool recolectado = false;

    private void Start()
    {
        // Contar automáticamente los objetos con la etiqueta "Objeto" en la escena
        totalObjetos = GameObject.FindGameObjectsWithTag("Objeto").Length;

        // Actualizar el marcador al inicio
        ActualizarMarcador();
    }

    private void OnEnable()
    {
        // Suscribirse al evento de carga de nivel
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Cancelar suscripción al evento de carga de nivel
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reinicia el contador al cargar un nuevo nivel
        ReiniciarContador();
        // Actualiza el total de objetos del nuevo nivel
        totalObjetos = GameObject.FindGameObjectsWithTag("Objeto").Length;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !recolectado)
        {
            recolectado = true;
            ControladorSonido.Instance.EjecutarSonido(objetoRecolectado); // Evita que el objeto sea recolectado más de una vez
            objetosRecolectados++;
            ActualizarMarcador();
            Destroy(gameObject);
        }
    }

    private void ActualizarMarcador()
    {
        // Actualizar el texto del marcador en la UI
        if (marcadorTexto != null)
        {
            marcadorTexto.text = $"Objetivo: {objetosRecolectados}/{totalObjetos}";
        }
    }

    public static void ReiniciarContador()
    {
        // Reinicia el contador de objetos recolectados
        objetosRecolectados = 0;
    }
}
