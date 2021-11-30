using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] float endTime = 0.33f;
    [SerializeField] GameObject bulletPrefab;
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

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity;
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //collision.gameObject.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity * 2;
        if (collision.gameObject.layer == 9)
        {
            GameObject bullet = Instantiate(bulletPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
            bullet.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity * 2;
        } else if (collision.gameObject.layer == 10)
        {
            Debug.Log("Add event to increase bullets");
        }
    }
}
