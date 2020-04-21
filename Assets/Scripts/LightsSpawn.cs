using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsSpawn : MonoBehaviour
{

    List<GameObject> lights = new List<GameObject>();
    public GameObject lightPref;
    LightsColourChange lgc;
    Vector3 lightLoc = new Vector3();
    public int numLights = 10;

    // Start is called before the first frame update
    void Start()
    {
        //lights = 

        for (int i = 0; i < numLights; i++)
        {
            GameObject Light = GameObject.Instantiate(lightPref, this.transform);
            lights.Add(Light);
            Light.transform.SetParent(this.transform);

            int rand = Random.Range(0, 100);
            Light.transform.position = this.gameObject.transform.position;
            Light.transform.eulerAngles = new Vector3(0, 36 * i, 0);
            Light.transform.Translate(Vector3.forward * 10);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
