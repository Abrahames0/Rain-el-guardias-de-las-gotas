using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoRecolectable : MonoBehaviour
{
    public static int objetosRecolectados = 0; // Contador de objetos recolectados
    public Text marcadorTexto;                 // Referencia al texto de la UI
    private static int totalObjetos;  
    
    [SerializeField] private AudioClip objetoRecolectado;         // Total de objetos en la escena

    private void Start()
    {
        // Contar automáticamente los objetos con la etiqueta "Objeto" en la escena
        totalObjetos = GameObject.FindGameObjectsWithTag("Objeto").Length;

        // Actualizar el marcador al inicio
        ActualizarMarcador();
    }
private bool recolectado = false;

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
}
