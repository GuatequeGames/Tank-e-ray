using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Functions for the camera to follow the player.
/// The camera will be above the player looking down to it.
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    [Header("Player")]
    public Transform playerPosition;

    [Header("Camera Settings")]
    public int zoom;

    int height = 50; //default distance
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeZoom();
        transform.position = new Vector3(playerPosition.position.x, height-zoom, playerPosition.position.z);
    }

    void ChangeZoom()
    {
        if(Input.GetAxis("Mouse ScrollWheel") >0 && zoom<40 )
        {
            
            zoom += 1;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom > -30)
        {

            zoom -= 1;
        }
    }
}
