using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShield : MonoBehaviour
{
    public int health = 3;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            try
            {
                other.gameObject.GetComponent<Enemy>().health = 0;
            }
            catch (NullReferenceException e){}
            try
            {
                other.gameObject.GetComponent<SmallAsteroid>().health = 0;
            }
            catch (NullReferenceException e){}
            try
            {
                other.gameObject.GetComponent<Alien>().health = 0;
            }
            catch (NullReferenceException e){}

            health -= 1;
        }
    }
}
