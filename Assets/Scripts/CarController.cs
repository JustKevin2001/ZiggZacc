using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Attributes
    [Header("Speed")]
    [SerializeField] float moveSpeed; 
    private bool movingLeft = true;
    private bool firstInput = true;


    private void Start()
    {
        StartCoroutine("RandomMoveSpeed");
    }

    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckInput();
        }

        EndGame();
    }

    private void EndGame()
    {
        if (transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime; 
    }

    void CheckInput()
    {
        // If first input then ignore everything
        if(firstInput)
        {
            firstInput = false;
            return;
        }


        // zero means left mouse => click chuot trai
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if(movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
            movingLeft = true;    
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {
            GameManager.instance.IncrementScore(1);  
            other.gameObject.SetActive(false);
        }

        else if(other.gameObject.tag == "Bigger_Diamond")
        {
            GameManager.instance.IncrementScore(3);
            other.gameObject.SetActive(false);
        }
    }


     IEnumerator RandomMoveSpeed()
    {
        while(true)
        {
            yield return new WaitForSeconds(11f);
            if(GameManager.instance.score <= 60)
            {
                moveSpeed += 2;
            }
            else
            {
                moveSpeed += 3;
            }
        }
    }
}


// Neu vi tri car < hon 1 gia tri nhat dinh => End game