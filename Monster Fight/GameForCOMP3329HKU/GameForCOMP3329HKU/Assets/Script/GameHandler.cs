using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public Transform playerTransform;
    GameObject player = null;
    public Transform pfHealthBar;

    public static string currentScene = "";
    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        cameraFollow.Setup(() => playerTransform.position);

        player = GameObject.FindGameObjectWithTag("Player");
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Dungeon")
        {

            player.GetComponent<Transform>().position = new Vector2(-10f, -3f);
        }
        if (currentScene == "Dungeon1")
        {
            player.GetComponent<Transform>().position = new Vector2(-16f, -3f);
        }
        if (currentScene == "Dungeon2")
        {
            player.GetComponent<Transform>().position = new Vector2(-9f, 5f);
        }
        if (currentScene == "Dungeon3")
        {
            player.GetComponent<Transform>().position = new Vector2(-13f, -2f);
        }

        if (currentScene == "Dungeon4")
        {
            player.GetComponent<Transform>().position = new Vector2(-13f, -2f);
        }

    }
}
