using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = transform.position;

        newCameraPosition.x = player.position.x;

        if (player.position.y > transform.position.y)
        {
            newCameraPosition.y = player.position.y;
        }

        if (player.position.y < transform.position.y)
        {
            newCameraPosition.y = player.position.y;
        }
        newCameraPosition.z = transform.position.z;

        transform.position = newCameraPosition;
    }
}
