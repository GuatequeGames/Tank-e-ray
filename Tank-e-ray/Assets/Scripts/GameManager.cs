using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;//PARA PODER USAR LOS TEXTOS DE LA INTERFAZ DE UNITY
using UnityEngine.SceneManagement;//INCLUIR SIEMPRE QUE QUERAMOS HACER CARGA DE ESCENAS

public class GameManager : MonoBehaviour
{

    public int enemiesDestroyed;
    public GameObject panelGameOver;
    public TextMeshProUGUI textEnemiesKilled; 
    public Image [] Enemies;

    [Header("UI ENEMY")]
    public GameObject panelUIEnemy;
    public Image enemyHealth; // actual enemy life

    int nEnemies;
    void Start()
    {
        if(nEnemies == 10)
        {
            GameOver();
        }
    }

    void Update()
    {
        
    }

    public void addEnemyCount()
    {
        Enemies[nEnemies].gameObject.SetActive(true);
        nEnemies++;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        panelGameOver.SetActive(true);
        textEnemiesKilled.text = nEnemies.ToString();
    }

    public void LoadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Cargar la escena de nombre "Gameplay"
    }
    public void showEnemyUI(GameObject enemy)
    {
        Debug.Log("Aquí entra");
        panelUIEnemy.SetActive(true);
        enemyHealth.fillAmount = enemy.GetComponent<EnemyHealth>().currentHealth/ enemy.GetComponent<EnemyHealth>().maxHealth;
    }
    public void hideEnemyUI()
    {
        panelUIEnemy.SetActive(false);

    }
}
