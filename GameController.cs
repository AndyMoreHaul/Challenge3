using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text RestartText;
    public Text GameOverText;
    public Text winText;

    private bool gameOver;
    private bool Restart { get; set; }
    private int score;

        void Start()
    {
        gameOver = false;
        Restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        score = 0;
        UpdateScore ();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if
            (Input.GetKeyDown(KeyCode.L))
           if (gameOver)
        {
            SceneManager.LoadScene("SpaceShooter");
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if (gameOver)
            {
                RestartText.text = "Press 'L' for Restart";
                Restart = true;
                break;
            }
        }
    }
    public void AddScore (int newScoreValue)
    {
      score += newScoreValue;
        UpdateScore();
    }
  void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (score >= 100)
        {
            winText.text = "Game Created By Andrew Jankowski";
            gameOver = true;
            Restart = true;
        }
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;
    }

   
}