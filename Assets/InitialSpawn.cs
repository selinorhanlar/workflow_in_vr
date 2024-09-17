using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSpawn : MonoBehaviour
{
    public Transform spawnPoint; // Assign your SpawnPoint in the Inspector

    void Start()
    {
        if (spawnPoint != null)
        {
            // Set the position and rotation of the XR Rig to the SpawnPoint's position and rotation
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
        }
        else
        {
            Debug.LogWarning("SpawnPoint is not assigned!");
        }
    }
}
