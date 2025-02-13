using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public static EnemyAttack Instance {  get; private set; }
    [Header("Shoot")]
    [SerializeField]
    private GameObject prefabBullet;
    [SerializeField]
    //Posicion de salida de las balas
    private Transform[] posRotBullet;
    [SerializeField]
    //Tiempo entre intervalos de disparo
    private int timeBetweenBullet;
    [SerializeField]
    private AudioSource shootAudio;
    private void Awake()
    {
        Instance = this;
        shootAudio=GetComponent<AudioSource>();
        //Llamamos al metodo Attack cada un intervalo de tiempo
        InvokeRepeating("Attack",1,timeBetweenBullet);
    }
    void Attack()
    {
        //mientras la vida del jugador sea superior a cero los enemigos atacaran
        if (PlayerHealth.Instance.currentHealth >0)
        {
            //con este metodo, activamos el audio de disparo y instanciamos las balas del enemigo para disparar
            shootAudio.Play();
            for (int i = 0; i < posRotBullet.Length; i++)
            {
                Instantiate(prefabBullet, posRotBullet[i].position, posRotBullet[i].rotation);
            }
        }
    }
}
