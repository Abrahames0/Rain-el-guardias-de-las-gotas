using Cinemachine;
using UnityEngine;

public class CameraFollowSetup : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;

    void Start()
    {
        GameObject jugador = GameObject.FindWithTag("Player");
        
        if (jugador != null && cinemachineCamera != null)
        {
            cinemachineCamera.Follow = jugador.transform;
            cinemachineCamera.LookAt = jugador.transform;
            Debug.Log("Cinemachine configurada para seguir al jugador: " + jugador.name);
        }
        else
        {
            Debug.LogError("No se encontró el jugador o la Cinemachine Virtual Camera.");
        }
    }
}
