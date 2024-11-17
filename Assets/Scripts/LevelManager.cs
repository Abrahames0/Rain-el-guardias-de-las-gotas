using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hola jku"); 
    }

    public void BotonStart(){
        Debug.Log("inciando jeugo");
        SceneManager.LoadScene(1);    
    }
    public void BotonReglas(){
        Debug.Log("Reglas Juego");
        SceneManager.LoadScene(6);    
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
