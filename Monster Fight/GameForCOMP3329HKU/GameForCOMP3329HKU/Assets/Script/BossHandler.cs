using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHandler : MonoBehaviour
{
    GameObject obj = null;
    public GameObject canvasObject;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.Find("Boss");
        if (obj == null)
        {
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().win = true;
        canvasObject.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}
