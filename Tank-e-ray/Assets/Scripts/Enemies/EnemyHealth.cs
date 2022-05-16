using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [Header("Life Parameters")]
    public float maxHealth; //salud máxima del enemigo
    public float currentHealth; //salud actual
    public float damageBullet; //el daño que me hace la bala  
    public float damageBomb; // daño que hace la bomba del player

    public Image lifeBar;//la imagen de la interfaz que representa la barra de vida, LA INTERFAZ VA COMO HIJO Y ES CANVAS WORLD SPACE

    AudioSource damaged, damagedBomb;
    GameManager gameManager;

    MovementPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>();
        damaged = gameObject.GetComponents<AudioSource>()[2];
        damagedBomb = gameObject.GetComponents<AudioSource>()[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            currentHealth -= damageBullet;
            lifeBar.fillAmount = currentHealth / maxHealth;
            damaged.Play();
            Destroy(other.gameObject);

        }
        if (other.CompareTag("PlayerBomb"))
        {
            currentHealth -= damageBomb;
            lifeBar.fillAmount = currentHealth / maxHealth;
            damagedBomb.Play();
            Destroy(other.gameObject);

        }

        if (currentHealth <= 0)
        {
            gameManager.addEnemyCount();
            player.stopAiming();
            Destroy(gameObject);
        }
    }
}
