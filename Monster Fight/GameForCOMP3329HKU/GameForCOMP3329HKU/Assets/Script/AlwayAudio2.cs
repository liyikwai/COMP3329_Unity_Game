using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlwayAudio2 : MonoBehaviour
{

	public GameObject obje;
	GameObject obj = null;
	GameObject player = null;
    GameObject healthBar = null;

    // Use this for initialization
    void Start()
	{
		obj = GameObject.FindGameObjectWithTag("Sound");
		if (obj == null)
		{
			obj = (GameObject)Instantiate(obj);
		}

		player = GameObject.FindGameObjectWithTag("Player");
		if (player == null)
		{
			player = (GameObject)Instantiate(player);
		}

    }

    // Update is called once per frame
    void Update()
    {
	}
}
