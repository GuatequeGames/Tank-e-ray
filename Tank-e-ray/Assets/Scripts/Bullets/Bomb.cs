using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int force;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce((Vector3.up+rb.transform.forward) * force); //Apply a parabolic force
        Destroy(gameObject, 3); // We destroy it after 3 seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
