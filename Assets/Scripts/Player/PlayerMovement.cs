using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance {  get; private set; }    
    [Header("Speed")]
    [SerializeField]
    private int speed = 20;
    [SerializeField]
    private int turnSpeed = 200;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        Movement();
        Turning();
    }
    //movemos al jugador mediante a,w,s,d
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction.normalized*speed*Time.deltaTime);
    }
    //rotamos la camara y al jugador mediante el movimiento de raton
    void Turning()
    {
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");
        Vector3 rotation=new Vector3(-yMouse, xMouse,0);
        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime);
    }
}
