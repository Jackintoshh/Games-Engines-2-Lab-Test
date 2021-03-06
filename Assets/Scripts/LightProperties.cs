﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightProperties : MonoBehaviour
{
    public bool isActive = false;
    public bool isChanging = false;
    public bool isNotActive = false;
    Color lightCol;
    float time;
    int randTime;



    // Start is called before the first frame update
    void Start()
    {
        //Choose starting colour for each light randomly
        int rand = (int)Random.Range(0, 3);
        //Debug.Log(rand);
        if(rand == 0)
        {
            lightCol = Color.green;
            this.GetComponent<Renderer>().material.color = lightCol;
            isActive = true;
        }
        if (rand == 1)
        {
            lightCol = Color.yellow;
            this.GetComponent<Renderer>().material.color = lightCol;
            isChanging = true;
        }
        if (rand == 2)
        {
            lightCol = Color.red;
            this.GetComponent<Renderer>().material.color = lightCol;
            isNotActive = true;
        }

        randTime = (int)Random.Range(5, 11);

    }

    // Update is called once per frame
    void Update()
    {
        //Update light states
        time += Time.deltaTime;

        if(time > randTime && isActive)
        {
            time = 0f;
            isChanging = true;
            isActive = false;
            lightCol = Color.yellow;
            this.GetComponent<Renderer>().material.color = lightCol;

            if (isChanging && time > 4f)
            {
                time = 0f;
                lightCol = Color.red;
                isNotActive = true;
                isChanging = false;

                this.GetComponent<Renderer>().material.color = lightCol;
                randTime = (int)Random.Range(5, 11);
            }
        }

        if (time > randTime && isNotActive)
        {
            time = 0f;
            isActive = true;
            lightCol = Color.green;
            this.GetComponent<Renderer>().material.color = lightCol;
            
            randTime = (int)Random.Range(5, 11);
        }

        if (isChanging && time > 4f)
        {
            time = 0f;
            lightCol = Color.red;
            isNotActive = true;
            isChanging = false;

            this.GetComponent<Renderer>().material.color = lightCol;
            randTime = (int)Random.Range(5, 11);
        }

    }
}
