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
    [SerializeField] private float health = 4;
    private Rigidbody2D rb;
    private Collider2D collider2;
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

     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (!collision.collider.CompareTag("Sword")) return;
         
         health--;
         AudioManager.instance.PlaySFX("SwordHit");
         GameEventsManager.Instance.entityEvents.HitEntity(gameObject.name);
         GameEventsManager.Instance.playerEvents.PlayerExperienceGained(-1);
         if (!(health <= 0)) return;
         
         AudioManager.instance.PlaySFX("MobDeath");
         GameObject.Destroy(this.gameObject);
         GameEventsManager.Instance.entityEvents.KilledEntity(gameObject.name);
         GameEventsManager.Instance.playerEvents.PlayerExperienceGained(-15);
     }
}
