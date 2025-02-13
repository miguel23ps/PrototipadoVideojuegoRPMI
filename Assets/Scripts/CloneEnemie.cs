using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneEnemie : MonoBehaviour
{
    public static CloneEnemie instance {  get; private set; }
    [Header("Respawn Enemy")]
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    Transform[] posRot;
    [SerializeField]
    float timeBetweenEnemies=1.5f;
    private void Awake()
    {
        instance=this;
    }
    //creamos los enemigos en una de las posiciones de los empty de forma aleatoria cada vez
    void CreateEnemies()
    {
        int n =Random.Range(0,posRot.Length);
        Instantiate(enemyPrefab, posRot[n].position, posRot[n].rotation);
    }
    //repetimos la llamada al metodo anterior cada cierto tiempo
    public void Start()
    {
        InvokeRepeating("CreateEnemies", 1.0f, timeBetweenEnemies);
    }
}
