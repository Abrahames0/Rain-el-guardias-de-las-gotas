using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private NewBehaviourScript jugador;

    private void Start()
    {
        // Encuentra el objeto con el tag "Player"
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();
        
        if (jugador != null)
        {
            Debug.Log("Jugador encontrado: " + jugador.gameObject.name);
            jugador.MuerteJugador += ActivarMenu; // Suscribirse al evento de muerte del jugador
            Debug.Log("Evento MuerteJugador suscrito.");
        }
        else
        {
            Debug.LogError("No se encontró el jugador.");
        }

        // Verifica que el menú de Game Over esté asignado
        if (menuGameOver != null)
        {
            menuGameOver.SetActive(false);  // Asegúrate de que esté desactivado al principio
            Debug.Log("Menú de Game Over asignado correctamente.");
        }
        else
        {
            Debug.LogError("El menú de Game Over no está asignado.");
        }
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        Debug.Log("Activando el menú de Game Over.");
        menuGameOver.SetActive(true); // Activa el menú de Game Over
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre); // Carga la escena del menú principal
    }

    public void Salir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); // Cierra el juego
        #endif
    }
}
