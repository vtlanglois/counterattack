using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] float endTime = 0.33f;
    float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(endTime < currentTime)
        {
            Destroy(gameObject);
        } else
        {
            currentTime += Time.deltaTime;
        }
    }
}
