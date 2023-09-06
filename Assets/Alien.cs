using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public float speed = 10.0f;
    public int health = 20;

    public bool destinationReached = false;
    public float timer = 0.0f;
    public GameObject alienLaserPrefab = null;
    public GameObject alienWeapon = null;

    public GameObject player = null;
    public int points = 5;
    public int score = 0;
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Instantiate(alienLaserPrefab, alienWeapon.transform.position, alienWeapon.transform.rotation);
            timer = 0;
        }
        
        if (destinationReached == false)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);   
        }
        
        if (health < 1)
        {
            score = player.gameObject.GetComponent<PlayerController>().score;
            score += points;
            player.gameObject.GetComponent<PlayerController>().score += score;
            Destroy(gameObject);
        }

        if (gameObject.transform.position.y < 3)
        {
            destinationReached = true;
        }
        
    }
}
