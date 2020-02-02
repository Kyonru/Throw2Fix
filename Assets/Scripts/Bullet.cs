using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject gameManager;
    public float bounceLimit = 3f;
    private float bounceCounter;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

    }
    private void Start()
    {
        bounceCounter = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceCounter += 1;
        if (bounceCounter >= bounceLimit)
            Destroy(gameObject);

        if (collision.gameObject.tag.Equals("Player"))
        {
            gameManager.GetComponent<DataManager>().catchedBullets += 1;

        }


    }
}
