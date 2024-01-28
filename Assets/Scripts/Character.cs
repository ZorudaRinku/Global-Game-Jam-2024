using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character instance;
    public float moveSpeed = 5f;
    public float health = 3;
    Vector2 movement;
    private Vector2 Location;
    private Vector2 Locationtest;
    private double localx;
    private double localy;
    private double localtx;
    private double localty;
    private float walkaudiocooldown;
    private Rigidbody2D rb;

    private float timer;
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
        Location = rb.position; 
         localx = Location.x;
         localy = Location.y;
         localty = Locationtest.y;
         localtx= Locationtest.x;
         if (timer <= 2)
         {
             timer += Time.deltaTime;
         }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        Locationtest = rb.position;
        if (localtx != localx || localty != localy)
        {
;
        walkaudiocooldown = walkaudiocooldown + 1 * Time.deltaTime;

        }

        if (walkaudiocooldown >= 25 * Time.deltaTime)
        {
            AudioManager.instance.PlaySFX("Walking");
            walkaudiocooldown = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (timer >= 2)
            {
                health = health -0.5f;
                if (health == 0)
                {
                    GameObject.Destroy(this.gameObject);
                }

                timer = 0;
            }
        }
    }
}
