using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyAi : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public float distancebetween = 4;
    public float distance;
    private Vector2 startingpostion;
    private float health = 4;
    private Rigidbody2D rb;
    private float timer = 0;
     void Start()
     {


         startingpostion = transform.position;
         rb = GetComponent<Rigidbody2D>();


     }

     void Update()
     {
         distance = Vector2.Distance(transform.position, Player.transform.position);
         Vector2 direction = Player.transform.position - transform.position;
         direction.Normalize();
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         
         if (distance < distancebetween)
         {
             transform.position =                                                                                                                    
                 Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);                                    
             transform.rotation = Quaternion.Euler(Vector3.forward * angle);                                                                         
         }
         else
         {
             transform.position = Vector2.MoveTowards(this.transform.position,startingpostion , speed * Time.deltaTime);
         }

         if (timer <= 2)
         {
             timer += Time.deltaTime;
         }
     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
         if(collision.collider.CompareTag("Sword"))
         {
             if (timer >= 2)
             {
                 health--;
                 Debug.Log("hit");
                 if (health <= 0)
                 {
                     GameObject.Destroy(this.gameObject);
                 }

                 timer = 0;
             }
             else ;
         }
     }
}
