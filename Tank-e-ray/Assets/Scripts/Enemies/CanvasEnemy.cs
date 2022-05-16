using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnemy : MonoBehaviour
{
    void Update()
    {
        //mira hace la Cámara de la escena que tenga la etiqueta de "MainCamera"
        transform.LookAt(Camera.main.transform.position);
    }
}

