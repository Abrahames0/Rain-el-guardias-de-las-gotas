using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullajeTuberiaMover : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float velocidadMovimiento;
    public LayerMask capaAbajo;
    public LayerMask capaEnfrente;
    public float distanciaEnfrente;
    public float distanciaAbajo;
    public Transform controladorAbajo;
    public Transform controladorEnfrente;
    public bool informacionAbajo;
    public bool informacionEnfrente;
    private bool mirandoDerecha = true;

    private void Update(){
        rb2d.velocity = new Vector2(velocidadMovimiento, rb2d.velocity.y);

        informacionEnfrente = Physics2D.Raycast(controladorEnfrente.position, transform.right, distanciaEnfrente, capaEnfrente);
        informacionAbajo = Physics2D.Raycast(controladorAbajo.position, transform.up*-1, distanciaAbajo, capaAbajo);

        if(informacionEnfrente || informacionAbajo){
            Girar();
        }
    }

    private void Girar(){
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidadMovimiento *= -1;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorAbajo.transform.position, controladorAbajo.transform.position + transform.up * -1 * distanciaAbajo);
        Gizmos.DrawLine(controladorEnfrente.transform.position, controladorEnfrente.transform.position + transform.right * -1 * distanciaEnfrente);
    }
}
