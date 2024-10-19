using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform camPosition;
    public Transform playerPosition;
    private Vector3 positionVector;
    void Update()
    {
        positionVector.Set(playerPosition.position.x, playerPosition.position.y, -1);
        camPosition.position = positionVector;
    }
}
