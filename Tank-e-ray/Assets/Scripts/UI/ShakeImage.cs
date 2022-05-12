using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script to animate elements of the interface
/// </summary>
public class ShakeImage : MonoBehaviour
{

    public float intensityShake; 
    public float durationShake;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        /*
         * We need to put this line because so the shake is centered in 0 rotation
         */
        transform.localScale = new Vector3(intensityShake / 20, intensityShake / 20, intensityShake / 20);
        transform.Rotate(0,0,intensityShake*durationShake/2);
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > durationShake)
        {
            if (timer > durationShake * 1.5)
            {
                transform.localScale = new Vector3(transform.localScale.x - intensityShake / 20 * Time.deltaTime, transform.localScale.y - intensityShake / 20 * Time.deltaTime, transform.localScale.z - intensityShake / 20 * Time.deltaTime);

            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x + intensityShake / 20 * Time.deltaTime, transform.localScale.y + intensityShake / 20 * Time.deltaTime, transform.localScale.z + intensityShake / 20 * Time.deltaTime);
            }
            transform.Rotate(0, 0, intensityShake*Time.deltaTime);
            if(timer > durationShake * 2)
            {
                timer = 0;
                transform.Rotate(0, 0, -intensityShake * Time.deltaTime);
            }
        }
        else 
        {
            if(timer > durationShake / 2) // Moment with rotation 0
            {
                transform.localScale = new Vector3(transform.localScale.x - intensityShake / 20 * Time.deltaTime, transform.localScale.y - intensityShake / 20 * Time.deltaTime, transform.localScale.z - intensityShake / 20 * Time.deltaTime);

            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x + intensityShake / 20 * Time.deltaTime, transform.localScale.y + intensityShake / 20 * Time.deltaTime, transform.localScale.z + intensityShake / 20 * Time.deltaTime);
            }
            transform.Rotate(0, 0, -intensityShake*Time.deltaTime);

        }

    }
}
