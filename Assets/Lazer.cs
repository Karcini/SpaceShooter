using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float speed = 10.0f;
    public int dmg = 1;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            try
            {
                other.gameObject.GetComponent<Enemy>().health -= dmg;
            }
            catch (NullReferenceException e){}
            try
            {
                other.gameObject.GetComponent<SmallAsteroid>().health -= dmg;
            }
            catch (NullReferenceException e){}
            try
            {
                other.gameObject.GetComponent<Alien>().health -= dmg;
            }
            catch (NullReferenceException e){}
            Destroy(gameObject);
        }
    }
}
