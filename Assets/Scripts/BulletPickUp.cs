using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPickUp : MonoBehaviour
{
    public Text bulletText;
    public int plus = 3;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharacterController2D player = collision.gameObject.GetComponent<CharacterController2D>();
            if (player != null)
            {
                player.bulletAmount += plus;
                player.bulletText.text = player.bulletAmount.ToString();
                player.bulletText.color = new Color(1, 1, 1);

                Destroy(gameObject);
            }
        }
    }
}
