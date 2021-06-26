using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float destroyTime = 2f;

    public float distance;
    public int damage = 10;
   
    public GameObject destEffect;

    void Update()
    {
        Destroy(gameObject, destroyTime);
        if(this.transform.childCount > 0 && this.transform.GetChild(0).gameObject != null){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance);
            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                if(hit.collider.GetComponent<Enemy>() != null)
                {
                    hit.collider.GetComponent<Enemy>().DamageEnemy(damage);
                }               

                Destroy(this.transform.GetChild(0).gameObject);
                Instantiate(destEffect, transform.position, Quaternion.identity);
            }
        }

    }
}
