using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    private Animator anim;
    Vector2 movement;
    Vector2 mousePos;

    [SerializeField]
    private int health;
    private bool hit = true;

    public AudioClip hitClip, deathClip;
    public static string currentScene = "";

    public Transform player;
    public bool PickUp = false;
    public string letter;
    public Weapon w1;
    public Weapon w2;
    public bool Live = true;
    public GameObject lost;
    public GameObject end;
    public bool win = false;
    public int gem = 0;
    private Transform NPCPos;

    public AudioClip gemClip;

    public GameObject first;
    public GameObject yes;
    public GameObject no;

    public int count = 0;

    public GameObject shield;
    private int shieldCount = 3;
    public bool buy = false;
    public bool X = false;
    void Start()
    {

            DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        /*NPCPos = GameObject.FindGameObjectWithTag("NPC").transform;
        if (Vector2.Distance(transform.position, NPCPos.position) < 1.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, NPCPos.position, moveSpeed * Time.deltaTime);
        }*/

        if (health > 0)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -24f, 14f), Mathf.Clamp(transform.position.y, -19f, 13f));
        }

        if (PickUp)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                GameObject.FindWithTag("Player").GetComponent<Shooting>().currentWeapon = w1;
            }

            if (Input.GetKey(KeyCode.E))
            {
                GameObject.FindWithTag("Player").GetComponent<Shooting>().currentWeapon = w2;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space");
            Debug.Log(buy);
            Debug.Log(shieldCount);
            if (buy == true && shieldCount > 0)
            {
                Debug.Log("Space1");
                protect();
            }

        }

        if (win)
        {
            end.SetActive(true);
        }

        OnGUI();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health > 0)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 270f;
            rb.rotation = angle;
        }

    }
    IEnumerator HitBoxOff()
    {
        hit = false;
        anim.SetTrigger("Hit");
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy" || target.tag == "BossBullet")
        {
            if (hit && X == false)
            {
                SoundManager.instance.PlaySoundFX(hitClip, 0.5f);
                StartCoroutine(HitBoxOff());
                health--;
                Destroy(GameObject.Find("LifeBox").transform.GetChild(0).gameObject);
                if (health < 1)
                {
                    SoundManager.instance.PlaySoundFX(deathClip, 0.5f);
                    StartCoroutine(Death());
                }
            }
        }

        if (target.tag == "Gun")
        {
            Destroy(target.gameObject);
            PickUp = true;
        }

        if (target.name == "Exit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (target.name == "Entry")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (target.name == "NPC")
        {
            if(count == 0)
            {
                Debug.Log("Collide2");
                first.SetActive(true);
                moveSpeed = 0;
            }
            count++;
        }

        if (target.tag == "Gem")
        {
            gem++;
            SoundManager.instance.PlaySoundFX(gemClip, 0.5f);
            Destroy(target.gameObject);
        }


    }
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 25;
        GUI.Label(new Rect(100,140, 1000, 1000), "X " + gem, myStyle);
    }

    public void Yes()
    {
        if(gem > 20)
        {
            gem -= 20;
            buy = true;
            first.SetActive(false);
            yes.SetActive(true);
        }
        else
        {
            No();
        }
    }

    public void No()
    {
        first.SetActive(false);
        no.SetActive(true);
    }

    public void Continue()
    {
        first.SetActive(false);
        yes.SetActive(false);
        no.SetActive(false);
        moveSpeed = 8f;
    }

    public void protect()
    {
        X = true;
        shield.SetActive(true);
        Invoke("protectAfter", 5);
    }

    public void protectAfter()
    {
        shield.SetActive(false);
        shieldCount--;
        X = false;
    }
    IEnumerator Death()
    {
        lost.SetActive(true);
        SoundManager.instance.PlaySoundFX(deathClip, 1f);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }

}
