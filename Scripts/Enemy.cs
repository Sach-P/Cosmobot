using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [System.Serializable]
    public class EnemyStats
    {
        public int Health = 100;
    }

    public int damage;
    bool canTakeDamage = true;
    public float damageTime = 1f;

    public EnemyStats enemyStats = new EnemyStats();

    public Transform player;
    private Rigidbody2D rigid;
    private Vector2 movement;
    public float moveSpeed = 5f;

    public GameObject destEffect;

    void Start()
    {

       player = GameObject.FindGameObjectWithTag("Player").transform;
       rigid = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigid.rotation = angle;
        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rigid.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void DamageEnemy(int damage)
    {
        enemyStats.Health -= damage;
        if (enemyStats.Health <= 0)
        {
            
            GameMaster.KillEnemy(this);
            Instantiate(destEffect, new Vector3(transform.position.x, transform.position.y, -10), Quaternion.identity);

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();

            if (canTakeDamage)
            {
                if (player != null)
                {
                    player.DamagePlayer(damage);
                    StartCoroutine(WaitForSeconds());
                }

                
            }
            
        }
    }

    IEnumerator WaitForSeconds()
    {
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(damageTime);
        canTakeDamage = true;

    }
}
