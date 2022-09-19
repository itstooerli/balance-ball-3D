using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    /// <summary>
    /// The degree to which the board can be rotated
    /// (-10 such that up rotates the board forward)
    /// </summary>
    public float rotationRange = -10;

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal") * rotationRange;
        float vertical = Input.GetAxis("Vertical") * rotationRange;

        transform.rotation = Quaternion.Euler(vertical, 0, horizontal);
    }
}
