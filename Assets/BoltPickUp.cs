using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPickUp : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PowerUpController player = collision.gameObject.GetComponent<PowerUpController>();
            if (player != null)
            {
                player.ActivateBolt();
                Destroy(gameObject);
            }
        }
    }
}
