using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField]
    private int score;
    private int levelNumber;

    public bool spawn = true;

    public GameObject[] enemies;


    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
    IEnumerator UpgradeThePlayer()
    {
        score = 0;
        levelNumber++;
        yield return new WaitForSeconds(2);
    }
}
 