using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public string enemyTag;
    public GameObject gameOver;

    private void Start()
    {
        Time.timeScale = 1;
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Numlock))
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            if(collision.gameObject.tag == enemyTag)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
