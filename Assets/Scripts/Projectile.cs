using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 startPos;
    public float bulletSpeed;
    public float bulletDespawnRadius;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;

        if (Vector2.Distance(transform.position, startPos) >= bulletDespawnRadius)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Carrot"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
   
}
