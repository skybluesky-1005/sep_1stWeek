using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector3 cameraPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = cameraPos;
    }
}
