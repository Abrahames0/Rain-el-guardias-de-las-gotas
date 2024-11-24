using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void BotonStart(){
        Debug.Log("inciando jeugo");
        SceneManager.LoadScene(1);    
    }
    public void BotonReglas(){
        Debug.Log("Reglas Juego");
        SceneManager.LoadScene(7);    
    }

    public void BotonInicio(){
        Debug.Log("Inicio Juego");
        SceneManager.LoadScene(0);    
    }

    public void BotonSalir(){
        Debug.Log("Salio del juego");
        Application.Quit();
    }
}
