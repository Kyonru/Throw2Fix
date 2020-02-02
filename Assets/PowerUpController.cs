using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public float BoltTimeLimit;
    public float speedMod = 0.2f;
    private bool boltEnabled;
    private float localBoltTime;
    CharacterController2D player;


    void Start()
    {
        player = gameObject.GetComponent<CharacterController2D>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (boltEnabled)
        {
            if (localBoltTime >= BoltTimeLimit)
            {
                localBoltTime = 0f;
                boltEnabled = false;
                ChangPlayerSpeed(speedMod, false);
            }
            else
            {
                localBoltTime += 1 * Time.deltaTime;
            }
        }
        
    }

    public void ActivateBolt()
    {
        boltEnabled = true;
        ChangPlayerSpeed(speedMod, true);
    }

    void ChangPlayerSpeed(float speedModifier, bool increase)
    {
        if (increase)
        {
            player.speed *= 1f + speedModifier;
        }
        else
        {
            player.speed /= 1f + speedModifier;
        }
        
    }
}
