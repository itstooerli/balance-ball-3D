using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OceanLose : MonoBehaviour
{
    /// <summary>
    /// Audio to play when timer runs out
    /// </summary>
    public AudioClip LoseAudio;

    /// <summary>
    /// Audio source for the object
    /// </summary>
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(LoseAudio);
        Invoke("Reload", 1.6f);
    }
    
    /// <summary>
    /// Reloads the current scene if player collides with ocean
    /// </summary>
    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
