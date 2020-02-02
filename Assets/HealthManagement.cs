using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour
{
    public float playerHealth = 100f;
    public float enemyHealth = 0f;

    public SpriteRenderer playerBar;
    public SpriteRenderer enemyBar;


    // Start is called before the first frame update
    void Start()
    {
        playerBar.gameObject.transform.localScale = new Vector3(1, 1, 1);
        enemyBar.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }


    public float ReduceHealth(bool isPlayer, float damage)
    {
        float health = isPlayer ? playerHealth : enemyHealth;
        health -= damage;

        health = health <= 0 ? 0 : health;

        this.ChangeHealth(isPlayer, health);

        return health;
    }

    public float IncreaseHealth(bool isPlayer, float restoration)
    {
        float health = isPlayer ? playerHealth : enemyHealth;
        health += restoration;

        health = health >= 100 ? 100 : health;

        this.ChangeHealth(isPlayer, health);

        return health;
    }


    public void ChangeHealth(bool isPlayer, float health)
    {
        float healhPorcentage = health/100f;
        if (isPlayer)
        {
            playerHealth = health;
            playerBar.gameObject.transform.localScale = new Vector3(1, healhPorcentage, 1);
            playerBar.color = new Color(1, healhPorcentage, healhPorcentage);
        }
        else
        {
            enemyHealth = health;
            enemyBar.gameObject.transform.localScale = new Vector3(1, healhPorcentage, 1);
            enemyBar.color = new Color(1, healhPorcentage, healhPorcentage);
        }
    }
}
