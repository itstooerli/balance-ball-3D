using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GoalWin : MonoBehaviour
{
    /// <summary>
    /// The storage object for the global score
    /// </summary>
    private Storage globalStorage;

    /// <summary>
    /// The GameManager for the current level
    /// </summary>
    private GameManager gm;

    /// <summary>
    /// The Game Over Object to load when completing level 5
    /// This object only needs to be supplied for level 5
    /// </summary>
    public GameObject GameOverObject;

    /// <summary>
    /// The text component of the GameOverObject
    /// </summary>
    private static TMP_Text gameOverText;

    /// <summary>
    /// The audio clip to play when player completes the level
    /// </summary>
    public AudioClip LevelUpAudio;

    /// <summary>
    /// The audio source for the object
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Whether the player has completed the level
    /// This is to ensure the player doesn't restart the level
    /// while the audio is playing/next level loads
    /// e.g. when the timer runs out after reaching the goal
    /// </summary>
    private bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        globalStorage = FindObjectOfType<Storage>();
        gm = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        win = true;
        audioSource.PlayOneShot(LevelUpAudio);
        Invoke("LoadNextLevel", 0.9f);
    }

    /// <summary>
    /// Load the next scene
    /// Because the game isn't built, we're loading the scenes manually by name
    /// because the build indices aren't loaded when in Assets
    /// When level 5 is reached, the GameOver object is laoded and the game will restart in x seconds
    /// </summary>
    void LoadNextLevel()
    {
        globalStorage.SetScore(gm.GetDelta());
        string activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "LevelOne")
        {
            SceneManager.LoadScene("LevelTwo");
        }
        if (activeScene == "LevelTwo")
        {
            SceneManager.LoadScene("LevelThree");
        }
        if (activeScene == "LevelThree")
        {
            SceneManager.LoadScene("LevelFour");
        }
        if (activeScene == "LevelFour")
        {
            SceneManager.LoadScene("LevelFive");
        }
        if (activeScene == "LevelFive")
        {
            gameOverText = GameOverObject.GetComponent<TMP_Text>();
            gameOverText.text = "Congratulations! You cleared all of the levels! The game will automatically restart in 7 seconds as bonus rounds.";
            Invoke("RestartGame", 7);
        }
    }

    /// <summary>
    /// Reload the first level when level five is completed if player wants to continue
    /// </summary>
    private void RestartGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    /// <summary>
    /// Give whether the level has been completed
    /// </summary>
    /// <returns></returns>
    public bool GetWin()
    {
        return win;
    }

}
