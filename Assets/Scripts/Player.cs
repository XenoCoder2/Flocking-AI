using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Transform bulletSpawnPoint; 

    private Vector3 _mousePos;

    private float _moveSpeed = 15f;

    public float fireRate = 0.15f;

    public float resetFireRate;

    bool _hasFired = false;

    // Update is called once per frame
    void Update()
    {
        if (!MenuHandler.paused)
        {
            LookAtMouseDirection();
            Movement();
            Shoot();
        }
    }

    private void LookAtMouseDirection()
    {
        _mousePos = Input.mousePosition;
        Vector3 screenSpacePoint = Camera.main.ScreenToWorldPoint(_mousePos);

        Vector2 mDirection = new Vector2(screenSpacePoint.x - transform.position.x, screenSpacePoint.y - transform.position.y);

        transform.up = mDirection;
    }

    private void Movement()
    {
        Vector2 moveDir = Vector2.zero;

        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveDir *= _moveSpeed * Time.deltaTime;

        transform.position += (Vector3) moveDir;
    }

    private void Shoot()
    {
        if (_hasFired)
        {
            fireRate -= Time.deltaTime;

            if (fireRate <= 0)
            {
                fireRate = resetFireRate;
                _hasFired = false;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(projectilePrefab, bulletSpawnPoint.position, transform.rotation);
                _hasFired = true;
            }
        }
    }
}
