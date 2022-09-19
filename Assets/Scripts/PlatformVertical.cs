using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVertical : MonoBehaviour
{
    /// <summary>
    /// How far the platform can move in either direction from its starting position
    /// </summary>
    public float platformRange = 3;

    /// <summary>
    /// Which direction the platform will move
    /// </summary>
    private float platformDirection = 1;

    /// <summary>
    /// How fast the platform will move
    /// </summary>
    private float platformStep = 1;

    /// <summary>
    /// Where the platform starts
    /// </summary>
    private float startingPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y > startingPosition + platformRange)
        {
            platformDirection = -1;
        }
        if (transform.localPosition.y < startingPosition - platformRange)
        {
            platformDirection = 1;
        }

        transform.Translate(transform.up * Time.deltaTime * platformStep * platformDirection, Space.World);
    }
}
