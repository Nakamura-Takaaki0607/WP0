using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject enemy;
    private EnemyManagerScript enemyManagerScript;
    //private GameObject game;
    //private GameManagerScript gameManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.Find("GameManager");
        //enemyManagerScript = enemy.GetComponent<EnemyManagerScript>();

        transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameManagerScript.IsGameClear() == true)
        //{
        //    Time.timeScale = 0;
        //}
        //if (gameManagerScript.IsGameClear() == false)
        //{
        //    Time.timeScale = 1;
        //}

        if (enemyManagerScript.IsGameOver() == true)
        {
            Time.timeScale = 0;
        }
        if (enemyManagerScript.IsGameOver() == false)
        {
            Time.timeScale = 1;
        }

        //Vector3 velocity = new Vector3(0, 0, Time.deltaTime);
    }
}
