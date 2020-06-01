using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyScript : MonoBehaviour
{
    // Public variable that contains the speed of the enemy

    private List<Rigidbody2D> EnemyRBs;

    public float speed = 3;
    private Transform playerPos;

    public Rigidbody2D rb;

    private Rigidbody2D RB;
    Vector2 playerPosition;

    private float repelRange = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        RB = GetComponent<Rigidbody2D>();
        if(EnemyRBs == null)
        {
            EnemyRBs = new List<Rigidbody2D>();
        }

        EnemyRBs.Add(RB);
    }

    private void OnDestroy()
    {
        EnemyRBs.Remove(RB);
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > 1.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
    
    }

    void FixedUpdate()
    {        
        Vector2 repelForce = Vector2.zero;
        foreach(Rigidbody2D enemy in EnemyRBs)
        {
            if (enemy == RB)
                continue;

            if(Vector2.Distance(enemy.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (RB.position - enemy.position).normalized;
                repelForce += repelDir;
            }
        }

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 lookDir = playerPosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 270f;
        rb.rotation = angle;


    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;

        if (obj.gameObject.tag == "Bullet")
        {
            GameObject effect = Instantiate(obj.GetComponent<Bullet>().hitEffect, transform.position, Quaternion.identity);
            Destroy(obj.gameObject);
            Destroy(effect, 0.3f);
        }

    } 

}
