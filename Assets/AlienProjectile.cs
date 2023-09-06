using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienProjectile : MonoBehaviour
{
    public float speed = 5.0f;

    public GameObject player = null;
    public float playerX = 0;
    public float playerY = 0;
    public float playerZ = 0;
    public Vector3 playerPosition = new Vector3();
    void Start()
    {
        playerX = player.gameObject.transform.position.x;
        playerY = player.gameObject.transform.position.y;
        playerZ = player.gameObject.transform.position.z;
        playerPosition = new Vector3(playerX,playerY,playerZ);
    }

    void Update()
    {
        //transform.Translate(playerPosition * Time.deltaTime * speed);
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "PlayerProjectile")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().playerHP -= 1;
        }
    }
}
