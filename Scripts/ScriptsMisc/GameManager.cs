using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score;

    private void Awake()
    {
        Instance = this;
        Save save = SaveManager.LoadPoints();
        if (save != null)
        {
            score += save.score;
        }
    }
    private void Update()
    {

        SaveManager.SavePoints(this);
    }
    public GameManager(GameManager gameManager)
    {
        score = gameManager.score;
    }

    public void AddToScore(int scoreToAdd)
    {

        score += scoreToAdd;

    }
}
