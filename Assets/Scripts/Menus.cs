using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameFinishedScreen;
    public GameObject gameManager;

    public Text amountOfBulletsFired;
    public Text amountOfBulletHitted;
    public Text time;
    public Text bulletsCatched;
    public Text score;

    TimeManager timeManager;
    DataManager dataManager;
    HealthManagement healthManagement;

    bool isPaused = false;

    float minutes;
    float seconds;
    float enemyHealth;
    float playerHealth;

    private void Start()
    {
        dataManager = gameManager.GetComponent<DataManager>();
        timeManager = gameManager.GetComponent<TimeManager>();
        healthManagement = gameManager.GetComponent<HealthManagement>();
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
            if (!isPaused)
			{
				Pause();
			}
			else if (isPaused)
			{
				Resume();
			}
       }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isPaused)
                gameManager.GetComponent<DataManager>().bulletsFired += 1;

        }


        minutes = timeManager.minutes;
        seconds = timeManager.seconds;
        enemyHealth = healthManagement.enemyHealth;
        playerHealth = healthManagement.playerHealth;

        if ((minutes == 0 && (int)seconds == 0)|| playerHealth <= 0 || enemyHealth >= 100)
        {
            GameOver();
        }

        amountOfBulletsFired.text = "You Fired "+dataManager.bulletsFired + " bullets";
        amountOfBulletHitted.text = "You hitted "+dataManager.bulletsHittedOnEnemy +" on enemy vehicles";
        time.text = "Time left: " +timeManager.RecordTime(1);
        bulletsCatched.text = "You catched "+dataManager.catchedBullets+" bullets";
        score.text = "Total score: "+Score();    
    }
    public void StartButton()
    {
        isPaused = !isPaused;
        SceneManager.LoadScene(1);
    }
	
		

    public void Pause()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            isPaused = !isPaused;
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
            isPaused = !isPaused;
            Time.timeScale = 1f;
        }
    }

	public void MainMenuButton()
	{
        SceneManager.LoadScene(0);
		Resume();
	}

    

    public void GameOver()
    {
        Time.timeScale = 0f;
        isPaused = true;
        gameFinishedScreen.SetActive(true);
        
    }

    public float Score()
    {
        float score;
        float timeScore = minutes + seconds / 60f;
        float playerHealthScore = playerHealth / 100f;
        float accuracyScore = dataManager.bulletsHittedOnEnemy / dataManager.bulletsFired;
        float bulletsCatchedScore = dataManager.catchedBullets;

        score = timeScore + playerHealthScore + accuracyScore + bulletsCatchedScore;

        return score;
    }

}
