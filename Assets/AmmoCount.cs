using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    Text ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammo.text = "Ammo:";
        int shots = GameObject.Find("Gun").GetComponent<Gun>().shots;
        if (shots >= 10)
        {
            ammo.text += shots.ToString();
        } else if (shots > 0)
        {
            for (int i = 0; i < shots; i++)
            {
                ammo.text += "O";
            }
        } else
        {
            
            ammo.text = "EMPTY!";
        }
    }
}
