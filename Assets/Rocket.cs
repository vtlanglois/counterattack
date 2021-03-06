using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Acceleration());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator Acceleration()
    {
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 2, ForceMode2D.Impulse);
        StartCoroutine(Acceleration());
    }
}
