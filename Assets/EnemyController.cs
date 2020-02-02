using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 15f;
    public float spawnTime = 5f;
    public float range = 5f;

    private float localRespawnTime = 0f;

    private void Update()
    {

        if (localRespawnTime >= spawnTime)
        {
            localRespawnTime = 0f;
            this.Shoot();
        }
        else
        {
            localRespawnTime += 1 * Time.deltaTime;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(new Vector2(-1, Random.Range(-range, range)) * bulletForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("PlayerBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
