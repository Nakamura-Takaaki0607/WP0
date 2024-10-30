using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    public EnemyManagerScript enemyManagerScript;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GameObject enemyManager;
            EnemyManagerScript enemyManagerScript;
            enemyManager = GameObject.Find("EnemyManager");
            enemyManagerScript = enemyManager.GetComponent<EnemyManagerScript>();
            GameManagerScript.point += 1;
            enemyManagerScript.Hit();

            Destroy(other.gameObject);
        }
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (enemyManagerScript.IsGameOver() == true)
        {
            GameManagerScript.point = 0;
        }
    }
}
