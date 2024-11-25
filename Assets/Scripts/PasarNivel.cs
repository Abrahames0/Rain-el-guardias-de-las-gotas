using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Verificar si se han recolectado todos los objetos
            if (ObjetoRecolectable.objetosRecolectados >= ObjetoRecolectable.totalObjetos)
            {
                // Si todos los objetos fueron recolectados, pasa al siguiente nivel
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                // Mostrar mensaje indicando que faltan objetos por recolectar (opcional)
                Debug.Log("Aún faltan objetos por recolectar para pasar al siguiente nivel.");
            }
        }
    }
}
