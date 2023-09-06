using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    public int health = 10;

    public bool touchedShield = false;
    public float maxShield = 5;
    
    public GameObject player = null;
    public int points = 3;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (health < 1)
        {
            player.gameObject.GetComponent<PlayerController>().score += points;
            Destroy(gameObject);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            print("Shields Took Critical Damage!");
            player.gameObject.GetComponent<PlayerController>().shieldUsage = maxShield;
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().playerHP -= 2;
        }
    }
    
}
