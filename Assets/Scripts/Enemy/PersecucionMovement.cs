using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecucionMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private int speed=20;
    [SerializeField]
    //Distancia que mantiene el enemigo
    private int distanceToPlayer = 6;
    private void Update()
    {
        //Mientras el Player siga vivo el enemigo se movera hacia el y lo perseguira, si no, salimos del update en el return
        if(PlayerMovement.Instance==null) return;
        transform.LookAt(PlayerMovement.Instance.transform.position);
        FollowPlayer();
    }
    void FollowPlayer()
    {
        //movemos al enemigo manteniendo la distancia de seguridad al player
        float distance = Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position);
        if (distance > distanceToPlayer)
        {
            transform.Translate(Vector3.forward*speed*Time.deltaTime);
        }
    }
}
