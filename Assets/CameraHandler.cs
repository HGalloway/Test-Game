using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform Player;
    public  Transform Camera;

    // Update is called once per frame
    void Update()
    {
        Camera.position = Player.position;
    }
}
