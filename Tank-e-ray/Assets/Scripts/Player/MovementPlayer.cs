using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Control the input of movement of the player with WASD
/// </summary>
public class MovementPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movement")]
    public int speed;
    public int speedRotation;

    [Header("Autoaim")]
    public LayerMask tankMask;
    Ray ray;
    RaycastHit hit;

    Vector3 directionToAim;//It stores the position for the player to turn to
    bool aiming; //true: aim to enemy tank. False: nothing
    GameObject enemy;

    public GameManager gameManager;


    AudioSource engine;

    void Start()
    {
        engine = GetComponents<AudioSource>()[4];
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        showUIEnemy();
        if (Input.GetMouseButton(1))
        {
            Debug.Log("apuntando al enemigo=");
            aimEnemy();
            
        }
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0) engine.volume = 1;
        else engine.volume = 0.5f;


        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * speedRotation * Time.deltaTime);

    }

    void aimEnemy()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, tankMask))
        {
            Debug.Log("Algo detecto");
            aiming = true;

            Vector3 direction = hit.transform.position - transform.position;
            directionToAim = direction;
            Debug.DrawRay(hit.transform.position, transform.position * 100, Color.green);

            enemy = hit.transform.gameObject;

            
        }

        float angleBetween = Vector3.SignedAngle(new Vector3(transform.forward.x, 0, transform.forward.z), new Vector3(directionToAim.x, 0, directionToAim.z), Vector3.up);

        if (aiming)
        {
            if (angleBetween < 0)
            {
                transform.Rotate(Vector3.up * -speedRotation * Time.deltaTime);
                Debug.Log("Rotandillo");

            }
            else if (angleBetween > 0)
            {
                Debug.Log("Rotandillo");

                transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
            }

        }
        
    }

    public void stopAiming()
    {
        aiming = false;
        gameManager.hideEnemyUI();
    }

    void showUIEnemy()
    {
        if (aiming)
        {
            gameManager.showEnemyUI(enemy);
        }
    }
}
    
