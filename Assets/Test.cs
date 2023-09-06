using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int x = 0;

    void Start()
    {
        while (x < 100)
        {
            print(x+1);
            x++;
        }

        for (int y=0; y<100; y++)
        {
            print(y+1);
        }
    }

    void Update()
    {
        
    }
}
