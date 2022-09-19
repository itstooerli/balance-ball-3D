using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    /// <summary>
    /// The object of the player
    /// </summary>
    public GameObject player;

    /// <summary>
    /// The starting distance from the camera to the player
    /// </summary>
    private Vector3 playerOffset;

    // Start is called before the first frame update
    void Start()
    {
        playerOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.position = player.transform.position + playerOffset;
    }
}
