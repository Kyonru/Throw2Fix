using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPickUp : MonoBehaviour
{
    private GameObject gameManager;
    private TimeManager timeManager;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

    }

    private void Start()
    {
        timeManager = gameManager.GetComponent<TimeManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timeManager.seconds += 10f;
            Destroy(gameObject);
        }
    }
}
