using UnityEngine;

public class RainController : MonoBehaviour
{
    public Material rainMaterial;

    void Update()
    {
        // Ajustar el tiempo del shader para animar la lluvia
        rainMaterial.SetFloat("_Time", Time.time);
        
        // Puedes ajustar otros parámetros, como la inclinación o cantidad de lluvia
        // rainMaterial.SetFloat("_Slant", 0.5f);
        // rainMaterial.SetFloat("_RainAmount", 300.0f);
    }
}
