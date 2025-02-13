using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance {  get; private set; }
    [Header("Health")]
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    public float currentHealth = 100;
    [SerializeField]
    private float damageBullet = 5;
    [Header("HealthBar")]
    [SerializeField]
    private Image lifeBar;
    [Header("FXExplosion")]
    [SerializeField]
    private ParticleSystem bigExplosion;
    [SerializeField]
    private ParticleSystem smallExplosion;
    private void Awake()
    {
        bigExplosion.Stop();
        smallExplosion.Stop();
        Instance = this;
        currentHealth=maxHealth;
        lifeBar.fillAmount = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        //cuando detecte una colision con el tag bulletenemy significa que nos han dado y perdemos vida y activamos la smallExplosion
        if (other.CompareTag("BulletEnemy"))
        {
            Debug.Log("The han dado");
            currentHealth-=damageBullet;
            lifeBar.fillAmount=currentHealth/maxHealth;
            smallExplosion.Play();
            Destroy(other.gameObject);
            //Si la vida del jugador llega a cero llamamos al metodo Death() que destruye al jugador y activa la bigExlosion
            if(currentHealth <= 0)
            {
                Death();
            }
        }
    }
    //Desemparentamos la camarada del player, hacemos play en la explosion final, destruimos al player y llamamos a la funcion game Over
    void Death()
    {
        Camera.main.transform.SetParent(null);
        bigExplosion.Play();
        Destroy(gameObject,0.3f);
        GameManager.instance.GameOver();
    }
}
