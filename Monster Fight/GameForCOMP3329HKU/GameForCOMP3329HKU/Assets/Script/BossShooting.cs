using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public Transform bossFire;
    public GameObject bossBullet;
    public float bulletForce = 20f;
    private float nextTimeOfFire = 0;
    public float Rate = 1;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeOfFire)
        {
            Shoot();
            nextTimeOfFire = Time.time + 1 / Rate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bossBullet, bossFire.position, bossFire.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-bossFire.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
    }

}
