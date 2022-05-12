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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        
        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * speedRotation * Time.deltaTime);

    }
}
