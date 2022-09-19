using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Object of the score UI
    /// </summary>
    public GameObject scoreObject;

    /// <summary>
    /// Object of the timer UI
    /// </summary>
    public GameObject timerObject;

    /// <summary>
    /// Object of the goal
    /// </summary>
    public GoalWin goalObject;

    /// <summary>
    /// Text component of the score UI
    /// </summary>
    private static TMP_Text scoreText;

    /// <summary>
    /// Text component of the timer UI
    /// </summary>
    private static TMP_Text timeText;

    /// <summary>
    /// Object that stores the global score
    /// </summary>
    private Storage globalStorage;

    /// <summary>
    /// The current global scsore
    /// </summary>
    private int currentScore;

    /// <summary>
    /// The score obtained during the level so far
    /// </summary>
    private int currentDelta;

    /// <summary>
    /// The amount of time to complete the level in seconds
    /// </summary>
    public int startingTime = 30;

    /// <summary>
    /// The current time left on the timer
    /// </summary>
    private int currentTime;

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
        // Set the score when the level starts with the global score
        scoreText = scoreObject.GetComponent<TMP_Text>();
        globalStorage = FindObjectOfType<Storage>();
        currentScore = globalStorage.GetScore();
        currentDelta = 0;
        scoreText.text = "Score: " + currentScore;

        // Set the timer when the level starts
        timeText = timerObject.GetComponent<TMP_Text>();
        currentTime = startingTime;
        timeText.text = currentTime.ToString();
        InvokeRepeating("ReduceTime", 1, 1);

        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Update to close out of application when playing
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>
    /// Updates the text on the score UI and the score obtained during the current level
    /// </summary>
    public void UpdateScore()
    {
        currentDelta++;
        scoreText.text = "Score: " + (currentScore + currentDelta);
    }

    /// <summary>
    /// Reduces the time on the timer and updates the text on the text UI
    /// </summary>
    void ReduceTime()
    {

        currentTime = int.Parse(timeText.text) - 1;
        if (currentTime == 0 && !goalObject.GetWin())
        {
            audioSource.PlayOneShot(LoseAudio);
            Invoke("Reload", 1.6f);
        }
        currentTime = Mathf.Max(0, currentTime);
        timeText.text = currentTime.ToString();
    }

    /// <summary>
    /// Gives the score obtained during this level so it can be passed to storage
    /// </summary>
    /// <returns></returns>
    public int GetDelta()
    {
        return currentDelta;
    }

    /// <summary>
    /// Reloads the current scene if timer runs out
    /// </summary>
    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
