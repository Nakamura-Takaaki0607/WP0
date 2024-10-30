using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public static bool isGameClear = false;
    public GameObject gameClearText;

    private void OnTriggerEnter(Collider other)
    {
        gameClearText.SetActive(true);
        isGameClear = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //if (isGameClear == true)
        //{
        //    isGameClear = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
