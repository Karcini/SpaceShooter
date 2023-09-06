using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SmallAsteroid : MonoBehaviour
{
    public float speed = 8.0f;
    public float health = 1;
    
    public int randomPathChange = 0;
    public int pathChange = 0;

    public GameObject player = null;
    public int points = 1;
    void Start()
    {
        randomPathChange = Random.Range(0, 3);
        pathChange = Random.Range(0, 3);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (health < 1)
        {
            player.gameObject.GetComponent<PlayerController>().score += points;
            Destroy(gameObject);
        }

        if (gameObject.transform.position.y < randomPathChange)
        {
            if (pathChange == 0)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

            //if  pathChange == 1  Stays on Course 

            if (pathChange == 2)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().playerHP -= 1;
        }
    }
}
