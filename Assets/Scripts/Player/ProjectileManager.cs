using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public Projectile self;
    public float maxActiveTime = 5f;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale *= self.size;
        StartCoroutine("ActiveTime");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, self.speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyManager>() )
        {
            collision.GetComponent<EnemyManager>().ProjectileHit(self.damage);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}


    IEnumerator ActiveTime()
    {
        yield return new WaitForSeconds(maxActiveTime);
        Destroy(gameObject);
    }
}
