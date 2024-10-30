using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject enemy;
    public AudioSource hitAudioSource;

    public GameObject gameOverText;
    public static bool isGameOver = false;

    public void Hit()
    {
        hitAudioSource.Play();
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void GameOverStart()
    {
        gameOverText.SetActive(true);
        isGameOver = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, new Vector3(6.5f, -2.5f, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(10.5f, -3.5f, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(14.5f, -2.5f, 0), Quaternion.identity);

        Instantiate(enemy, new Vector3(12.0f, 1.5f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
}
