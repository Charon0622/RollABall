using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Reference to the player
    public GameObject player;

    // hold offet value    
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame
    // But it is guaranteed to run  after all items have been processed in update
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
