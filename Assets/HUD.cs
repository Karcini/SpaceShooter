using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] healthPoints;
    public GameObject energy = null;
    public GameObject player = null;

    public float energyLength = 0;
    public int currentHp = 0;
    public float currentEnergy = 0;

    public GameObject[] specialCharges;
    public int currentSpecialCharges = 3;
    void Start()
    {
        for(int x=0; x<healthPoints.Length ; x++)
        {
            if (healthPoints[x] != null)
            {
                currentHp += 1;
            }
        }
        currentSpecialCharges = player.gameObject.GetComponent<PlayerController>().specialGunCharges;
        currentEnergy = 0;
        
        print("Your Max HP is "+currentHp);
        print("You have "+currentSpecialCharges+" special charges remaining");
    }

    void Update()
    {
        if (player.gameObject.GetComponent<PlayerController>().playerHP < currentHp)
        {
            for (int x = 0; x < healthPoints.Length; x++)
            {
                if (x == currentHp-1)
                {
                    healthPoints[currentHp-1].SetActive(false);
                    currentHp -= 1;
                }
            }
        }

        if (player.gameObject.GetComponent<PlayerController>().shieldMax >= currentEnergy)
        {
            if (player.gameObject.GetComponent<PlayerController>().shieldUsage > currentEnergy)
            {
                currentEnergy += 0.25f;
                //.25 of a max of 5 is 5%
                //size of object's X is 6.431942
                //5% reduction in energy of X is .32
                energy.gameObject.transform.localScale -= new Vector3(0.32f,0,0);
            }   
        }

        if (player.gameObject.GetComponent<PlayerController>().specialGunCharges < currentSpecialCharges)
        {
            for (int x = 0; x < specialCharges.Length; x++)
            {
                if (x == currentSpecialCharges-1)
                {
                    specialCharges[currentSpecialCharges-1].SetActive(false);
                    currentSpecialCharges -= 1;
                }
            }
        }
    }
}
