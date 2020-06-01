using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100;

    public AudioClip deathClip;
    public GameObject healthBar;

    public int scoreReward;
    public GameObject gem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            GameplayManager.instance.AddScore(scoreReward);
            SoundManager.instance.PlaySoundFX(deathClip, 0.5f);
            Instantiate(gem, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bullet")
        {
            health -= GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>().currentWeapon.damage;
            Destroy(target.gameObject);

            healthBar.transform.localScale = new Vector3(health / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }   
    }

}
