using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Square;
    void Update()
    {
        if (Square == null) return;
        Vector3 position = transform.position;
        position.x = Square.transform.position.x;
        transform.position = position;
    }
}
