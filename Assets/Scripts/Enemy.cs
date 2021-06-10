using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("speed of enemy")]
    float enemySpeed = 3f;

    Rigidbody enemyRb;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //finds player and puts rigidbody on enemy
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Makes enemy chase the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
