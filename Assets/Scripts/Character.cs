using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5f;

    Vector2 movement;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameEventsManager.Instance.playerEvents.PlayerHealthGained(-10);
        }
    }
}
