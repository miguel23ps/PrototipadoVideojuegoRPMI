using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityBullet : MonoBehaviour
{
    private int speed = 500; // Variable para ajustar la velocidad
    void Update()
    {
        //Damos velocidad a las balas hacia delante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void Start()
    {
        //destruimos el objeto despues de cinco segundos
        Destroy(gameObject, 5);
    }
}
