using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsSpawn : MonoBehaviour
{

    List<GameObject> lights = new List<GameObject>();
    public GameObject lightPref;
    public int numLights = 10;
    float radius = 10;
    public GameObject carPref;
    GameObject car;
    public int random;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Instantiate(carPref);

        //Instantiate lights around (0, 0, 0) with radius of 10
        for (int i = 0; i < numLights; i++)
        {
            GameObject Light = GameObject.Instantiate(lightPref, this.transform);
            lights.Add(Light);
            Light.transform.SetParent(this.transform);

            int rand = Random.Range(0, 100);
            Light.transform.position = this.gameObject.transform.position;
            Light.transform.eulerAngles = new Vector3(0, 360/numLights * i, 0);
            Light.transform.Translate(Vector3.forward * radius);
        }

        random = (int)Random.Range(0, numLights);

    }

    // Update is called once per frame
    void Update()
    {
        //Choose green light to be targeted at random
        if(lights[random].GetComponent<LightProperties>().isActive)
        {
            target = lights[random].transform.position;
        }
        //If the randomly selected light isn't active (green), choose another
        else
        {
            random = (int)Random.Range(0, numLights);
        }

    }
}
