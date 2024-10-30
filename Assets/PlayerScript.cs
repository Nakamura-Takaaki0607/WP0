using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public GameObject bombParticle;
    private AudioSource audioSource;
    public GameObject bullet;

    public GameObject enemyManager;
    private EnemyManagerScript enemyManagerScript;

    public int jumpPower;
    private bool isBlock = true;

    int bulletTimer = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
            Instantiate(bombParticle, transform.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyManagerScript.GameOverStart();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyManagerScript = enemyManager.GetComponent<EnemyManagerScript>();

        transform.rotation = Quaternion.Euler(0, 90, 0);

        audioSource = gameObject.GetComponent<AudioSource>();

        if(Time.timeScale == 0)
        {
            GameManagerScript.score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 5.0f;
        Vector3 v = rb.velocity;
        Vector3 velocity = new Vector3(0, 0, 1.0f);

        float stick = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.RightArrow) || stick > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("mode", true);
            v.x = moveSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || stick < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            animator.SetBool("mode", true);
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
            animator.SetBool("mode", false);
        }

        rb.velocity = v;

        if(isBlock == true)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                animator.SetBool("jump", true);
                rb.velocity = Vector3.up * jumpPower;
            }
            else
            {
                animator.SetBool("jump", false);
            }
        }

        if (GoalScript.isGameClear == true)
        {
            Time.timeScale = 0;
        }
        if (GoalScript.isGameClear == false)
        {
            Time.timeScale = 1;
        }

        //if (enemyManagerScript.IsGameOver() == true)
        //{
        //    rb.velocity = new Vector3(0, 0, 0);
        //    return;
        //}
    }

    void FixedUpdate()
    {
        if (enemyManagerScript.IsGameOver() == true)
        {
            if (bulletTimer == 0)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    Vector3 position = transform.position;
                    //position.x += 1.5f;
                    position.y += 2.0f;
                    //position.z += 1.0f;

                    if (transform.rotation.y > 0)
                    {
                        position.x += 1.5f;
                    }
                    else
                    {
                        position.x -= 1.0f;
                    }

                    GameObject ball = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                    Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                    ballRigidbody.AddForce(transform.forward * 400);

                    //Instantiate(bullet, position, Quaternion.identity);

                    bulletTimer = 1;
                }
            }
            else
            {
                bulletTimer++;
                if (bulletTimer > 40)
                {
                    bulletTimer = 0;
                }
            }

            return;
        }

        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f); ;
        float distance = 0.9f;
        Ray ray = new Ray(rayPosition, Vector3.down);
        isBlock = Physics.Raycast(ray, distance);

        if (bulletTimer == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 position = transform.position;
                //position.x += 1.5f;
                position.y += 2.0f;
                //position.z += 1.0f;

                if(transform.rotation.y > 0)
                {
                    position.x += 1.5f;
                }
                else
                {
                    position.x -= 1.0f;
                }

                GameObject ball = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                ballRigidbody.AddForce(transform.forward * 400);

                //Instantiate(bullet, position, Quaternion.identity);

                bulletTimer = 1;
            }
        }
        else
        {
            bulletTimer++;
            if(bulletTimer > 40)
            {
                bulletTimer = 0;
            }
        }
    }
}
