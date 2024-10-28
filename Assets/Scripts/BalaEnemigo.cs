using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float velocidad;
    public int daño;
    public int posicion;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * Vector2.left);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out NewBehaviourScript playerControler))
        {
            playerControler.TomarDañoPorDisparo(daño);
        }
    }   
}
