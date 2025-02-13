using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private float maxHealth=100;
    [SerializeField]
    private float danmageBullet = 20;
    [SerializeField]
    private float currentHealth = 100;
    [SerializeField]
    Image lifeBar;
    [SerializeField]
    ParticleSystem smallExplosion, bigExplosion;
    private void Awake()
    {
        smallExplosion.Stop();
        bigExplosion.Stop();
        currentHealth=maxHealth;
        lifeBar.fillAmount = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        //comprobamos si el objeto que ha colisionado con el enemigo es Bullet, si es asi, restamos vida al enemigo 
        if (other.CompareTag("Bullet"))
        {
            smallExplosion.Play();
            currentHealth-=danmageBullet;
            lifeBar.fillAmount=currentHealth/maxHealth;
            Destroy(other.gameObject);
            //si la vida del enemigo es menor a 0 llamamos al metodo muerte que destruye al enemigo
            if(currentHealth <= 0)
            {
                Death();
            }
        }
    }
    //destruye al enemigo
    void Death()
    {
        bigExplosion.Play();
        Destroy(gameObject,0.3f);
    }
}
