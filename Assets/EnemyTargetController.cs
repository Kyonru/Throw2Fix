using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyTargetController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.tag.Equals("PlayerBullet"))
        {
            gameObject.GetComponent<AIDestinationSetter>().SetTarget(collision.transform);
        }
    }
}
