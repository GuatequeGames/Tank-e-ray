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
    public GameObject bombPrefab;
    public GameObject bulletPrefab;
    public Transform shooterTransform;

    [Header("AutoFire")]
    public bool autoFire;
    public float autoFireRate;

    [Header("Bombs")]
    public int maxBombs;
    int nBombs;

    [Header("Interface Elements")]
    public Image reloadImage;

    float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        AutoFire();
        ShootBomb();


    }

    void AutoFire()
    {
        timer += Time.deltaTime;
        if (autoFire && timer >= autoFireRate)
        {
            Instantiate(bulletPrefab, shooterTransform.position, shooterTransform.rotation);
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            autoFire = !autoFire;
        }
    }

    void ShootBomb()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (nBombs == 0)
            {

                return;
            }
        }
        if (nBombs == 0) return;
        
    }
}
