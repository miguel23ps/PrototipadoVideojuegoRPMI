using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnemy : MonoBehaviour
{
    void Update()
    {
        //Hacemos que el canvas del enemigo siempre mire a la camara
        transform.LookAt(Camera.main.transform.position);
    }
}
