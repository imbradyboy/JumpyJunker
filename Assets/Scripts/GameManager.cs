using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject column;
    public float timeBetweenSpawn = 1.5f;


    public bool gameOver = false;
    public GameObject endUI;
    public Text score;
    private int counter;
    private int adjustedScore;

    public Text highScore;
    private int hs;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; // Reset Time to normal speed
        StartCoroutine("ColumnCreator");
        GetHighscore();
    }

    IEnumerator ColumnCreator()
    {
        while (!gameOver)
        {
            GameObject go = Instantiate(column, RandomHeight(), transform.rotation);
            Destroy(go, 10f);
            counter++;
            UpdateScore();
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

    }


    Vector3 RandomHeight()
    { 
        Vector3 height = transform.position;
        height.y = Random.Range(-1.9f, 4.1f);

        return height;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        endUI.SetActive(true);
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }

    void UpdateScore()
    {
        adjustedScore = counter - 1;

        score.text = "Score: " + adjustedScore.ToString();

        if(PlayerPrefs.GetInt("highscorejumpyjunker", hs) <= adjustedScore)
        {
            hs = adjustedScore;
            PlayerPrefs.SetInt("highscorejumpyjunker", hs);
            GetHighscore();
        }
    }

    void GetHighscore()
    {
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("highscorejumpyjunker", hs);

    }
}
