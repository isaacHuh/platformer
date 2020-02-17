using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerPos;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(playerPos.position[0],8,-12);
    }
}
