using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    [Header("Seguimiento")]
    [SerializeField]
    float followSpeed=30.0f;
    [SerializeField]
    float rotationSpeed=200;
    [SerializeField]
    Vector3 offset=new Vector3(0, 1.8f, -6.0f);
    private void LateUpdate()
    {
        //Aqui hacemos  que la camara siga al jugador mediante un calculo entre sus posiciones manteniendo la distancia con un offset
        Vector3 posicioDeseada = PlayerMovement.Instance.gameObject.transform.position + PlayerMovement.Instance.gameObject.transform.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, posicioDeseada, followSpeed * Time.deltaTime);
        Quaternion rotacionDeseada = Quaternion.LookRotation(PlayerMovement.Instance.gameObject.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, rotationSpeed * Time.deltaTime);
    }
}
