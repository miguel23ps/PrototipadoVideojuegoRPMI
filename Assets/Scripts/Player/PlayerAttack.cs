using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    //Posicion de salida de las balas
    private Transform[] posRotBullet;
    private AudioSource shootAudio;
    private void Awake()
    {
        shootAudio = GetComponent<AudioSource>();
        //Bloqueamos el cursor en la pantalla de juego
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Attack();
    }
    private void Attack()
    {
        //cuando presionamos clic derecho del raton, dispara las balas y se activa el audio de disparo
        if (Input.GetMouseButtonDown(0))
        {
            shootAudio.Play();
            for (int i = 0; i < posRotBullet.Length; i++)
            {
                Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
            }
        }
    }
}
