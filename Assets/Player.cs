using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    float horizontalInput, verticalInput;
    [SerializeField] public int health = 3;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (health <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, 0);
        Vector2 velocity = new Vector2(horizontalInput, verticalInput);
        rb.velocity += velocity.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer >= 9 && collision.gameObject.layer <= 12)
        {
            health--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer <= 12)
        {
            health--;
        }
    }
}
