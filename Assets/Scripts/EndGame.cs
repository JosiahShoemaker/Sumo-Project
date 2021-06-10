using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    bool gameOn;

    [SerializeField]
    Text gameOverText;

   
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
            gameOn = true;
            gameOverText.gameObject.SetActive(false);
        }

        if (player.transform.position.y < -10)
        {
            Destroy(player);
            gameOverText.gameObject.SetActive(true);
            gameOn = false;
        }
    }
}