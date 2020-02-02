using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum HealthValue
{
    fromPlayerToPlayer = 10,
    fromEnemyToPlayer = 20,
    fromPlayerToEnemy = 20,
}

public class BrokenTruck : MonoBehaviour
{
    public ParticleSystem brokenEffect;
    public bool isOnEnemySide;
    public int hitPoints = 3;
    private GameObject gameManager;
    private int currentHealth = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

    }
    void Start()
    {
      if (isOnEnemySide)
        {
            currentHealth = 0;
        }
        else if (!isOnEnemySide)
        {
            currentHealth = hitPoints;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth >= hitPoints)
        {
            brokenEffect.Play(false);
            currentHealth = hitPoints;
        }

       
      //  Debug.Log("Truck health is: " + hitPoints);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerBullet"))
        {
            currentHealth += 1;
            Destroy(collision.gameObject);
            if (isOnEnemySide)
            {
                gameManager.GetComponent<HealthManagement>().IncreaseHealth(false, (float)HealthValue.fromPlayerToEnemy);
                gameManager.GetComponent<DataManager>().bulletsHittedOnEnemy += 1;
            }
            else if (!isOnEnemySide)
            {
                gameManager.GetComponent<HealthManagement>().IncreaseHealth(true, (float)HealthValue.fromPlayerToPlayer);
                gameManager.GetComponent<DataManager>().bulletsHittedOnPlayer += 1;
            }
            
        }

        if (!isOnEnemySide)
        {
            if (collision.gameObject.tag.Equals("EnemyBullet"))
            {
                currentHealth -= 1;
                gameManager.GetComponent<HealthManagement>().ReduceHealth(true, (float)HealthValue.fromEnemyToPlayer);
                Destroy(collision.gameObject);
            }
        }


    }
}
