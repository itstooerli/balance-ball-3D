using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    /// <summary>
    /// The amount in degrees that the capsule will rotate each step
    /// </summary>
    public float degreeStep = 90;

    /// <summary>
    /// The GameManager object of the level to appropriately update the score
    /// </summary>
    private GameManager gm;

    /// <summary>
    /// The audio to be played when capsule is collided with
    /// </summary>
    public AudioClip CapsuleAudio;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = degreeStep * Time.deltaTime;
        transform.Rotate(0, step, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(CapsuleAudio, transform.position);
        gm.UpdateScore();
        Destroy(gameObject);
    }
}
