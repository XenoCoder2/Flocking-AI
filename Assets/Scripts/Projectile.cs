using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Variables
    //The start position of the projectile.
    public Vector3 startPos;
    //The speed of the bullet.
    public float bulletSpeed;
    //The radius the bullet despawns at.
    public float bulletDespawnRadius;
    #endregion

    #region Start
    // Start is called before the first frame update
    void Start()
    {
        //Set the start position to the current position.
        startPos = transform.position;
    }
    #endregion

    #region Update
    // Update is called once per frame
    void Update()
    {
        //Move the bullet in the direction it was spawned at and multiply its speed by bulletSpeed. 
        transform.position += transform.up * bulletSpeed * Time.deltaTime;

        //If the distance between the bullet and the startPos is greater than or equal to the bulletDespawnRadius.
        if (Vector2.Distance(transform.position, startPos) >= bulletDespawnRadius)
        {
            //Destroy the bullet.
            Destroy(gameObject);
        }
    }
    #endregion

    #region On Trigger Enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the object that the bullet collided with was a carrot.
        if (collision.gameObject.CompareTag("Carrot"))
        {
            //Destroy the carrot.
            Destroy(collision.gameObject);
            //Destroy the bullet.
            Destroy(gameObject);
        }
    }
    #endregion

}
