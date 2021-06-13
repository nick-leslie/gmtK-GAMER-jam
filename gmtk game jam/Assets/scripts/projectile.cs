using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float force;
    private Rigidbody2D rb;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right);
        rb.velocity = direction * force;
        transform.right = direction;
        //have the merior chage the transform.right of the projectile to be the reflected angle
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("reflector"))
        {
            direction = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal).normalized;
            transform.right = direction;
        }
    }
}
