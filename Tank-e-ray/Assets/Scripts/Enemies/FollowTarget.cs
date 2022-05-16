using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    [Header("IA Parameters")]
    public LayerMask layerTanks;
    public LayerMask layerWalls;
    public float distanceToDetect; //Distance where the enemy will detect the player
    public float distanceToShoot; // Distance where the enemy will stop and start shooting
    public int speed;
    public int turnSpeed;
    GameObject Target;

    [Header("Atack")]
    public GameObject bombPrefab;
    public Transform shooterTransform;
    public float autoFireRate;

    float timerBombs;

    //Raycast that aims to the player
    Ray ray; 
    RaycastHit hit;

    //Raycast that aims forward
    Ray rayForward;
    RaycastHit hitForward;

    AudioSource bombSound;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        bombSound = gameObject.GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        
        AllignWithPlayer();
    }

    void AllignWithPlayer()
    {
        ray.origin = transform.position;
        ray.direction = Target.transform.position - transform.position;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        rayForward.origin = transform.position;
        rayForward.direction = transform.forward;
        Debug.DrawRay(rayForward.origin, rayForward.direction * 100, Color.yellow);

        timerBombs += Time.deltaTime;//We actualize the timerBombs var so the first shoot is instant
        if (Physics.Raycast(ray, out hit, distanceToDetect, layerWalls)) return; //If the player is behind a wall, the enemy don't move
        if (Physics.Raycast(ray, out hit, distanceToDetect, layerTanks))
        {
            //Debug.Log("Distance to player: " + hit.distance);
            //We set the translation of the enemy in order to get closer to the player
            if (hit.distance > distanceToShoot)
            {
                transform.Translate((Target.transform.position - transform.position).normalized * speed * Time.deltaTime);
            }
            else if (hit.distance < distanceToShoot)
            {
                transform.Translate((Target.transform.position - transform.position).normalized * -speed * Time.deltaTime);
            }
            
            // We set the rotation of the enemy in order to aim to the player
            float angleBetween = Vector3.SignedAngle(new Vector3(rayForward.direction.x, 0, rayForward.direction.z), new Vector3(ray.direction.x, 0, ray.direction.z), Vector3.up);
            if (angleBetween != 0)
            {
                if (angleBetween < 0)
                {
                    transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);

                }
                else if (angleBetween > 0)
                {

                    transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
                }
            }
            else  if(hit.distance > distanceToShoot -0.5f && hit.distance < distanceToShoot+0.5f)
            {
                ShootToPlayer();
            }


        }
    }
    void ShootToPlayer()
    {
        
        if(timerBombs > autoFireRate)
        {
            bombSound.Play();
            Instantiate(bombPrefab, shooterTransform.position, shooterTransform.rotation);
            timerBombs = 0;
        }
        
    }
}
