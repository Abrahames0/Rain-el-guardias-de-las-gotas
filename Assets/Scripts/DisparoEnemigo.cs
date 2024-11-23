using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public Transform controladorDisparo;
    public float distanciaLinea;
    public LayerMask capaJugador;
    public bool jugadorRango;
    public GameObject balaEnemigo;
    public float tiempoEntreDisparo;
    public float tiempoUltimoDisparo;
    public float tiempoEsperaDisparo;
    
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jugadorRango = Physics2D.Raycast(controladorDisparo.position, transform.right, distanciaLinea, capaJugador);
        

        if(jugadorRango){
            if(Time.time > tiempoEntreDisparo + tiempoUltimoDisparo)
            {
                tiempoUltimoDisparo = Time.time;
                Invoke(nameof(Disparar), tiempoEntreDisparo);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distanciaLinea);
    }

    private void Disparar()
    {
        Instantiate(balaEnemigo, controladorDisparo.position, controladorDisparo.rotation);
        
    }
}
