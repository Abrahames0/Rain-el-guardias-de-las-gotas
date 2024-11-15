using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject pantallaAjustes;

    private bool juegoPausado = false;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("Juego Pausado " + juegoPausado.ToString());
            if(juegoPausado){
                Reanular();
            }
            else {
                Pausa();
                Debug.Log("Pausa");
            }
        }
    }

    public void ClicPausa() {
        Debug.Log("Nueva Pasa");
    }

    public void Pausa(){
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanular(){
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        pantallaAjustes.SetActive(false);
    }

    public void Reiniciar(){
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar () {
        juegoPausado = false;
        Debug.Log("Cerrando Juego");
        Application.Quit();
    }

    public void AbrirAjustes() {
        menuPausa.SetActive(false);
        pantallaAjustes.SetActive(true);
    }

    public void CerrarAjustes() {
        pantallaAjustes.SetActive(false);
        menuPausa.SetActive(true); 
    }
}
