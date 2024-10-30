using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject backblock;
    public GameObject goal;
    public GameObject coin;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pointText;
    public GameObject goalParticle;

    public static int score = 0;
    public static int point = 0;

    int[,]map =
        {
            { 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0, 0,0,0,3,0,0,0,0,0,0, 0,3,0,0,0,0,0,0,0,0, 0,0,0,3,3,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,1,1,1,0,0, 0,0,0,0,0,3,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,1,1,1, 0,0,0,0,0,0,0,0,0,0, 0,1,1,0,0,0,0,0,2,0 },
            { 0,0,0,0,0,0,0,3,0,0, 0,1,1,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,1,1,1,0 },
            { 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,1,1,0,0, 0,0,1,1,1,1,0,0,0,0, 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,3,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,1,1,1,0,0, 0,3,0,0,0,1,1,1,1,1, 0,0,0,0,3,0,3,0,0,0, 0,0,0,3,0,0,0,0,0,0 },
            { 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1 },
        };

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);

        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);

        Vector3 position = Vector3.zero;

        for(int y = 0; y < lenY; y++)
        {
            for(int x = 0; x < lenX; x++)
            {
                position.y = -y + 5;
                position.x = x;

                if(map[y,x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                if(map[y, x] == 2)
                {
                    goal.transform.position = position;
                    goalParticle.transform.position = position;
                }
                if(map[y, x] == 3)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }
            }
        }
        for (int y = 0; y < lenY; y++)
        {
            for (int x = 0; x < lenX; x++)
            {
                position.x = x;
                position.y = -y + 5;
                position.z = 3;
                Instantiate(backblock, position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalScript.isGameClear == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }

        scoreText.text = " COIN  " + score;
        pointText.text = "POINT " + point;
    }
}
