using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    #region Properties

    public float[] LanePositions
    {
        get
        {
            return lanePositions;
        }
    }

    public static int HighScore
    {
        get
        {
            return highScore;
        }
    }

    public float Score
    {
        get
        {
            return score;
        }
    }
    
    public float CHECK_DIST 
    {
        get { return CHECKING_DISTANCE;  }
    }


    #endregion

   

    private float[] lanePositions = {-4.0f, -2.0f, 0.0f, 2.0f, 4.0f };

    private static int highScore;
    [SerializeField] private int score;

    private const float CHECKING_DISTANCE = 1000.0f;

    [Header("Managers")]
    public LevelManager levelManager;
    public SpawningManager spawningManager;
    public PlayerMovement playerManager;
    public FollowCamera cameraManager;

    [Header("HUD")]
    public GameObject HUD;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;

    [Header("Game Over Screen")]
    public GameObject gameOverScreen;
    public TextMeshProUGUI resultText;

    private GameObject player; 

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartGame();
        SetHighScore(PlayerPrefs.GetInt("High Score"));
    }


    private void Update()
    {
        if (CheckDistanceTravelled())
        {
            ResetWorld();
        }

    }


    private void ResetWorld()
    {
        playerManager.ResetPlayer();
        levelManager.ResetWorld();
        spawningManager.ResetObjects();
    }

    private bool CheckDistanceTravelled()
    {
        if (player.transform.position.z >= CHECKING_DISTANCE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        score = 0;

        StartCoroutine(UpdateScore(0.5f));
        
        playerManager.RestartPlayer();
        levelManager.ResetWorld();
        spawningManager.RestartObjects();
        
        HUD.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void EndGame()
    {
        cameraManager.ShakeCamera();
        playerManager.speed = 0.0f;
        StopAllCoroutines();
        HUD.SetActive(false);
        gameOverScreen.SetActive(true);
        SetHighScore();
    }

    private void SetHighScore(int hScore)
    {
        HighScoreText.text = "HIGH SCORE: " + hScore;
        highScore = hScore;
    }

    private void SetHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);
        }

        HighScoreText.text = "HIGH SCORE: " + highScore;
    }


    private IEnumerator UpdateScore(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        score++;
        resultText.text = ScoreText.text = "SCORE: " + score;
        StartCoroutine(UpdateScore(0.5f));
    }


}
