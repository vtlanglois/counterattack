using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 15f;
    [SerializeField] float fireTimer = 2f;
    float currentTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        // LookAt 2D
        Vector3 target = player.transform.position;
        // get the angle
        Vector3 norTar = (target - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        // rotate to angle
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.rotation = rotation;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(fireTimer);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation );
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        StartCoroutine(Shoot());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(fireTimer-0.5f);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 2, ForceMode2D.Impulse);
        StartCoroutine(Move());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
