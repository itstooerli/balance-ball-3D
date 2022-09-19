using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    /// <summary>
    /// The global score
    /// </summary>
    private int score = 0;

    /// <summary>
    /// This is the global score object that should be carried forward for each level
    /// The object should not be destroyed.
    /// </summary>
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int delta)
    {
        score += delta;
    }
}
