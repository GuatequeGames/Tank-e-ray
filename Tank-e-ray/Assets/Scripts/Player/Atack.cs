using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Controls the shoot from the tanks.
/// If autoFire is TRUE it keeps shooting bullets forward 
///     we can disable it with SPACE
/// </summary>

public class Atack : MonoBehaviour
{
    [Header("Atack")]
    public GameObject bombAim;
    public GameObject bombPrefab;
    public GameObject bulletPrefab;
    public Transform shooterTransform;

    [Header("AutoFire")]
    public bool autoFire;
    public float autoFireRate;
   

    [Header("Bombs")]
    public float bombAimRate;
    public bool aimBomb;
    public UIPlayer playerInterface;


    AudioSource autoFireSound, bombSound, bombReload; //Sound Effects Variables
    float timer;
    float timerBombAim;


    // Start is called before the first frame update
    void Start()
    {
        autoFireSound = gameObject.GetComponents<AudioSource>()[0];
        bombSound = gameObject.GetComponents<AudioSource>()[1];
        bombReload = gameObject.GetComponents<AudioSource>()[2];
        
    }

    // Update is called once per frame
    void Update()
    {

        AutoFire();
        ShootBomb();
        ReloadBombs();


    }

    void AutoFire()
    {
        timer += Time.deltaTime;
        if (autoFire && timer >= autoFireRate)
        {
            Instantiate(bulletPrefab, shooterTransform.position, shooterTransform.rotation);
            autoFireSound.Play();
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            autoFire = !autoFire;
        }
    }

    void ShootBomb()
    {
        AimBomb();
       
        
        if (Input.GetMouseButtonDown(0))
        {
            if (playerInterface.currentBombs != 0)
            {
                Instantiate(bombPrefab, shooterTransform.position, shooterTransform.rotation);
                bombSound.Play();
                playerInterface.currentBombs--;
                playerInterface.UpdateNumberOfBombs();
            }
        }
        
    }
    void ReloadBombs()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (playerInterface.currentBombs < playerInterface.capacityBombs)
            {
               
                playerInterface.currentBombs= playerInterface.capacityBombs;
                bombReload.PlayDelayed(0.5f);
                playerInterface.ReloadBombs();
            }
        }
    }

    void AimBomb()
    {
        timerBombAim += Time.deltaTime;
        if (aimBomb && timerBombAim >= bombAimRate)
        {
            Instantiate(bombAim, shooterTransform.position, shooterTransform.rotation, shooterTransform);
            timerBombAim = 0;
        }
    }
}
