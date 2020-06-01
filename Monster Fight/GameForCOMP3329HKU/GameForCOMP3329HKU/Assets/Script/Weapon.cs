using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeaponSpr;
    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 20;
    public float bulletForce = 20f;

    public AudioClip[] shootClips;

    /*public void Shoot()
    {
        Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
    }*/

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, GameObject.Find("FirePoint").transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(GameObject.Find("FirePoint").transform.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);

        SoundManager.instance.PlaySoundFX(shootClips[Random.Range(0, shootClips.Length)], Random.Range(.8f, 1));
    }
}
