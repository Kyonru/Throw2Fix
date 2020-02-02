using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed;
    public int bulletAmount = 5;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject crosshair;
    public GameObject dashEffect;
    public Camera cam;
    public float dashDistance;
    public float bulletForce = 5f;
    private bool playerDashed = false;
    private Vector3 lastMoveDir;
    Rigidbody2D rb;
    Vector2 move;
    Vector2 mousePos;
    private float timeSpawn;
    public float limTime;
    public bool arc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeSpawn = limTime;
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal") * speed;
        move.y = Input.GetAxisRaw("Vertical") * speed;

        if(timeSpawn >= limTime)
        {
            timeSpawn = limTime;
            arc = true;

        }
        else
        {
            timeSpawn += 1 * Time.deltaTime;
            arc = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && arc)
        {
            playerDashed = true;
            timeSpawn = 0;
        }
        
        if (move != Vector2.zero)
        {
            lastMoveDir = move.normalized;
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        crosshair.transform.position = mousePos;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        


    }

    private void FixedUpdate()
    {

       if (playerDashed)
        {
            GameObject smoke = Instantiate(dashEffect, transform);
            smoke.transform.parent = null;
            playerDashed = false;  
            RaycastHit2D raycasthit = Physics2D.Raycast(transform.position, lastMoveDir, dashDistance);
            if (raycasthit.collider == null)
            {
                transform.position += lastMoveDir * dashDistance;
            }
            else
            {
                transform.position += lastMoveDir * dashDistance * 0.1f;
            }

        }

        //move player code
        Vector2 position = rb.position;
        position = position + move;
        rb.MovePosition(position);

        //look to camera code
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        
        
    }

    public void Shoot()
    {
        if (bulletAmount > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
            bulletAmount -= 1;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            enemies[0].GetComponent<AIDestinationSetter>().SetTarget(bullet.transform);

        }

    }

    
}
