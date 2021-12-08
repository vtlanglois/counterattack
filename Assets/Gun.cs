using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    [SerializeField] public float bulletForce = 1f;
    [SerializeField] public float meleeForce = 5f;
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public GameObject meleePrefab;
    [SerializeField] GameObject player;
    [SerializeField] public int shots = 6;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        if (Input.GetButtonDown("Fire1") && shots > 0)
        {
            Shoot();
            GameObject.Find("Main Camera").GetComponent<ShakeBehavior>().TriggerShake();
            shots--;
        } else if (Input.GetButtonDown("Fire2"))
        {
            Melee();
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);

    }

    void Melee()
    {
        GameObject melee = Instantiate(meleePrefab, transform.position, transform.rotation);
        Rigidbody2D rb = melee.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * meleeForce, ForceMode2D.Impulse);
    }


}