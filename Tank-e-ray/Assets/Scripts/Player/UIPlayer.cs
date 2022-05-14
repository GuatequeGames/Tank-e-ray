using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [Header("Interface Elements")]
    public Image backgrounBullets; 
    public Image bulletsImage;
    public Image healthBar;
    public Image reloadWarning;

    [Header("Life Parameters")]
    public float maxHealth;//salud máxima del player
    public float currentHealth;//salud actual
    public float damageBullet;//el daño que me hace la bala del enemigo

    [Header("Bomb Parameters")]
    public int capacityBombs;
    public int currentBombs;
    int maxBombs = 5; //It is the maximum number of bombs limited by the original image


    AudioSource powerUp;
    AudioSource HitReceived;


    void Start()
    {
        bulletsImage.fillAmount = (float) currentBombs / maxBombs;
        backgrounBullets.fillAmount = (float) capacityBombs / maxBombs;
        powerUp = GetComponents<AudioSource>()[3];
        HitReceived = gameObject.GetComponents<AudioSource>()[5];
    }

    // Update is called once per frame
    void Update()
    {
        ReloadMesage();
    }
    public void ReloadMesage()
    {
        if (currentBombs == 0 && !reloadWarning.IsActive())
        {
            reloadWarning.gameObject.SetActive(true);
        }
        else if(currentBombs >0)
        {
            reloadWarning.gameObject.SetActive(false);

        }
    }

    public void UpdateNumberOfBombs()
    {
        bulletsImage.fillAmount = (float)currentBombs / maxBombs;
    }

    public void ReloadBombs()
    {
        Invoke("UpdateNumberOfBombs", 2f);
    }
    public void UpdatecapacityBombs()
    {
        backgrounBullets.fillAmount = (float)capacityBombs / maxBombs;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExtraBomb"))
        {
            if(capacityBombs < maxBombs)
            {
                capacityBombs++;
                currentBombs = capacityBombs;
                UpdatecapacityBombs();
                UpdateNumberOfBombs();
                powerUp.Play();
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("EnemyBomb"))
        {

            currentHealth -= damageBullet;
            healthBar.fillAmount = currentHealth / maxHealth;
            HitReceived.Play();
            Destroy(other.gameObject);
            if(currentHealth <= 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {

    }

}
