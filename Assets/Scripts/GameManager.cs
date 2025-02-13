using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }
    [Header("PanelGameOver")]
    [SerializeField]
    GameObject panelGameOver;
    private void Awake()
    {
        instance = this;
    }
    //activamos el panel muerte, cancelamos la creacion de enemigos y desbloqueamos el cursor
    public void GameOver()
    {
        panelGameOver.SetActive(true);
        CloneEnemie.instance.CancelInvoke();
        Cursor.lockState = CursorLockMode.Confined;
    }
    //cargamos nueva escena
    public void LoadSceneLevel()
    {
        SceneManager.LoadScene("Level01");
    }
}
