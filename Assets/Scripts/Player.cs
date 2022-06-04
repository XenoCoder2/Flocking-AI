using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    //The prefab for the projectile.
    public GameObject projectilePrefab;
    //The spawn point of the projectile.
    public Transform bulletSpawnPoint; 
    //The current mouse position.
    private Vector3 _mousePos;
    //The move speed of the player.
    private float _moveSpeed = 15f;
    //The fire rate of the player.
    public float fireRate = 0.15f;
    //The reset fire rate for the projectiles, used to give the timer its initial value for better tweaking in inspector.
    public float resetFireRate;
    //A bool to check if a bullet was fired recently.
    bool _hasFired = false;
    #endregion

    #region Update
    // Update is called once per frame
    void Update()
    {
        //If the game is not paused.
        if (!MenuHandler.paused)
        {
            //Run the LookAtMouseDirection method.
            LookAtMouseDirection();
            //Run the Movement method.
            Movement();
            //Run the Shoot method.
            Shoot();
        }
    }
    #endregion

    #region Movement and Shooting
    private void LookAtMouseDirection()
    {
        //Set _mousePos to the mouse position.
        _mousePos = Input.mousePosition;
        //Create a Vector3 called screenSpacePoint and set it to the point of the mousePos on the screen.
        Vector3 screenSpacePoint = Camera.main.ScreenToWorldPoint(_mousePos);
        //Create a Vector2 called mDirection to get the location of the mouse relative to the player's transform.
        Vector2 mDirection = new Vector2(screenSpacePoint.x - transform.position.x, screenSpacePoint.y - transform.position.y);
        //Rotate the player to look at the mouse point.
        transform.up = mDirection;
    }

    private void Movement()
    {
        //Create a Vector2 called moveDir.
        Vector2 moveDir = Vector2.zero;
        //Set moveDir to the value from the Horizontal and Vertical axis.
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Multiply moveDir by moveSpeed and multiply it then by deltaTime.
        moveDir *= _moveSpeed * Time.deltaTime;
        //Move the player in the given direction.
        transform.position += (Vector3) moveDir;
    }

    private void Shoot()
    {
        //If the player has fired.
        if (_hasFired)
        {
            //Count down from fireRate.
            fireRate -= Time.deltaTime;

            //If the fireRate is less than or equal to 0.
            if (fireRate <= 0)
            {
                //Reset the fireRate.
                fireRate = resetFireRate;
                //Set _hasFired to false.
                _hasFired = false;
            }
        }
        //Else the player has not fired yet.
        else
        {
            //If the left mouse button is clicked.
            if (Input.GetMouseButton(0))
            {
                //Instantiate a bullet at the bulletSpawnPoint.
                Instantiate(projectilePrefab, bulletSpawnPoint.position, transform.rotation);
                //Set _hasFired to true.
                _hasFired = true;
            }
        }
    }
    #endregion
}
