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
    public Button restartButton;
    public Button menuButton;


    public GameObject Player;

    private PlayerHealth PlayerHealth;

    private void Start()
    {
        PlayerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        healthUi.text = "Health: " + PlayerHealth.health;

        GameOver(); // ABSTRACTION
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
}
