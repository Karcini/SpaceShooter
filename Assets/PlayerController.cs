using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Timers;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject[] weaponPlacements;
    public GameObject laserPrefab = null;
    
    public GameObject specialGunPrefab = null;
    public GameObject specialGunSpot = null;
    public int specialGunCharges = 3;
    
    public GameObject shield = null;
    public bool isUsingShield = false;
    public bool shieldsEmpty = false;
    public float timer = 0;
    public float shieldUsage = 0;
    public float shieldMax = 5f;
    public float shieldOverload = 0.5f;
    public float shieldOverloadTimer = 0f;
    public bool shieldAlreadyOff = true;
    public int playerHP = 3;
    
    public int score = 0;
    
    void Start()
    {
        shield.SetActive(false);
        score = 0;
        shieldUsage = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10) timer = 0;

        //Movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left *Time.deltaTime* speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right *Time.deltaTime* speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up *Time.deltaTime* speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down *Time.deltaTime* speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject weaponPlacements in weaponPlacements)
            {
                Instantiate(laserPrefab, weaponPlacements.transform.position, weaponPlacements.transform.rotation);   
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (specialGunCharges > 0)
            {
                Instantiate(specialGunPrefab, specialGunSpot.transform.position, specialGunSpot.transform.rotation);
                specialGunCharges -= 1;
            }
            else
            {
                print("Out of Special Charges");
            }
        }

        //Shields
        
        //bug you can hold down shift forever and you will never run out of shields, even if put directly on update

        if (shieldUsage >= shieldMax)
        {
            isUsingShield = false;
            shieldsEmpty = true;
            shield.SetActive(false);
        }
        
        shieldOverloadTimer += Time.deltaTime;
        if (shieldOverloadTimer >shieldOverload)
        {
            isUsingShield = false;
            shield.SetActive(false);
            shieldAlreadyOff = true;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (shieldsEmpty == false)
            {
                shield.SetActive(true);
                isUsingShield = true;
                timer = 0;
                shieldOverloadTimer = 0;
                shieldAlreadyOff = false;
            }

            if (shieldsEmpty)
            {
                print("Shields Empty!! Need More Energy!!");
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (shieldAlreadyOff == false)
            {
                if (shieldsEmpty == false)
                {
                    shield.SetActive(false);
                    isUsingShield = false;

                    shieldUsage += timer;
                    timer = 0;

                    if (shieldUsage > shieldMax)
                    {
                        shieldsEmpty = true;
                        shield.SetActive(false);
                    }
                }

                shieldAlreadyOff = true;
            }

            if (shieldAlreadyOff)
            {
                shieldUsage += 0.5f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isUsingShield == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                //bug This is detected twice specifically when shields are on
                // doesn't affect game play atm
                Destroy(other.gameObject);
            }
        }

        if (isUsingShield == false)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject);
                //playerHP -= 1;

                if (playerHP == 1)
                {
                    print("WARNING: Hull Critical!");
                }

                if (playerHP <= 0)
                {
                    print("Game Over");
                    print("You got "+score+ " points");
                    gameObject.SetActive(false);
                }
            }
        }

        if (other.gameObject.tag == "Energy")
        {
            shieldsEmpty = false;
            shieldUsage = 0;
            Destroy(other.gameObject);
        }
    }
}
