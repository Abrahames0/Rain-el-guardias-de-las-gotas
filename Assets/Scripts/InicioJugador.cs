using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InicioJugador : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera; // Asigna la Cinemachine Virtual Camera en el Inspector

    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");

        // Instancia el jugador seleccionado
        GameObject jugadorInstanciado = Instantiate(GameManajer.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);

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
    }
}
