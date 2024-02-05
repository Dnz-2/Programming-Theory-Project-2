using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    public TextMeshProUGUI healthUi;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI surviveText;
    public TextMeshProUGUI victoryText;
    public Button restartButton;
    public Button menuButton;

    public Behaviour gameManagerScript;
    public Behaviour enemyScript;

    private bool surviveTextTimer;

    public GameObject Player;

    private PlayerHealth PlayerHealth;
    private GameManager gameManager;

    private void Start()
    {
        PlayerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        surviveTextTimer = true;
    }
    private void Update()
    {
        healthUi.text = "Health: " + PlayerHealth.health;

        GameOver(); // ABSTRACTION
        SecondFloorSurvival(); // ABSTRACTION
        VictoryText(); // ABSTRACTION
    }

    private void GameOver()
    {
        if(PlayerHealth.health == 0)
        {
            gameOver.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            
            Player.transform.eulerAngles = new Vector3(transform.rotation.x,transform.rotation.y,-90);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void SecondFloorSurvival()
    {
        if(gameManager.playerInFloor == false && surviveTextTimer == true)
        {
            surviveText.gameObject.SetActive(true);
            StartCoroutine(StopSurviveText());
        }
    }

    IEnumerator StopSurviveText()
    {
        yield return new WaitForSeconds(5);
        surviveTextTimer = false;

        surviveText.gameObject.SetActive(false);
    }

    private void VictoryText()
    {
        if(gameManager.victory == true)
        {
            victoryText.gameObject.SetActive(true);
            gameManagerScript.enabled = false;
            enemyScript.enabled = false;
        }
    }
}
