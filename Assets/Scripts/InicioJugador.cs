using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InicioJugador : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera; // Asigna la Cinemachine Virtual Camera en el Inspector

    void Start()
    {
        // Obtén el índice del jugador seleccionado
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");

        // Instancia el jugador seleccionado
        GameObject jugadorInstanciado = Instantiate(GameManajer.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);

        // Asigna la etiqueta "Player" al jugador instanciado
        jugadorInstanciado.tag = "Player";

        // Asigna el jugador instanciado a la Cinemachine Virtual Camera
        if (cinemachineCamera != null)
        {
            cinemachineCamera.Follow = jugadorInstanciado.transform;
            cinemachineCamera.LookAt = jugadorInstanciado.transform;
            Debug.Log("Cinemachine configurada para seguir al jugador: " + jugadorInstanciado.name);
        }
        else
        {
            Debug.LogError("Cinemachine Virtual Camera no está asignada en el Inspector.");
        }

        // Notifica a todos los enemigos el nuevo jugador instanciado
        AsignarJugadorAEnemigos(jugadorInstanciado.transform);
    }

    private void AsignarJugadorAEnemigos(Transform jugadorTransform)
    {
        // Encuentra todos los enemigos con el script `EnemigoSigueJugador` (Nivel 2)
        EnemigoSigueJugador[] enemigosNivel2 = FindObjectsOfType<EnemigoSigueJugador>();
        foreach (var enemigo in enemigosNivel2)
        {
            enemigo.AsignarJugador(jugadorTransform);
        }

        // Encuentra todos los enemigos con el script `SeguirEnemigoSol` (Nivel 3)
        SeguirEnemigoSol[] enemigosSeguir = FindObjectsOfType<SeguirEnemigoSol>();
        foreach (var enemigo in enemigosSeguir)
        {
            enemigo.AsignarJugador(jugadorTransform);
        }

        // Encuentra todos los enemigos con el script `DisparoEnemigoSol` (Nivel 3)
        DisparoEnemigoSol[] enemigosDisparar = FindObjectsOfType<DisparoEnemigoSol>();
        foreach (var enemigo in enemigosDisparar)
        {
            enemigo.AsignarJugador(jugadorTransform);
        }

        Debug.Log("Jugador asignado a todos los enemigos.");
    }

}
