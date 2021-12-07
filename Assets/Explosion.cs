using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.12f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        yield return new WaitForSeconds(0.12f);
        Destroy(gameObject);
    }
}
