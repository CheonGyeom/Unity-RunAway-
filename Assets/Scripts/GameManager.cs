using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float currentPoints = 0;
    private float highscore;

    public TMP_Text pointsText;
    public TMP_Text Highscore;
    public TMP_Text EndScore;

    public GameObject endMenu;
    public GameObject pauseMenu;

    public GameObject Enemy;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            highscore = PlayerPrefs.GetFloat("Highscore");
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        InvokeRepeating("SpawnEnemy", 1, 9);
        InvokeRepeating("SpawnEnemy", 60, 15);
        InvokeRepeating("SpawnEnemy", 90, 25);
        InvokeRepeating("SpawnEnemy", 150, 5);
    }

    void Update()
    {
        currentPoints += Time.deltaTime;
        pointsText.text = currentPoints.ToString("F0");

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseMenu();
        }

    }

    public void UpdateHighscore()
    {
        if (currentPoints > highscore)
        {
            highscore = currentPoints;
            PlayerPrefs.SetFloat("Highscore", highscore);

            Highscore.text = "HighScore : " + highscore.ToString("F0");
        }
    }

    public void OpenEndMenu()
    {
        Time.timeScale = 0;

        UpdateHighscore();
        EndScore.text = "Score : " + currentPoints.ToString("F0");
        endMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        Highscore.text = "HighScore : " + highscore.ToString("F0");
        currentPoints = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoMainMenu()
    {
        Time.timeScale = 1;
        Highscore.text = "HighScore : " + highscore.ToString("F0");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OnPauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void OffPauseMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-20f, 20f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        float randomy = Random.Range(-10f, 10f); //적이 나타날 y좌표를 랜덤으로 생성해 줍니다.
        GameObject enemy = (GameObject)Instantiate(Enemy, new Vector2(randomX, randomy), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
    }   

}
