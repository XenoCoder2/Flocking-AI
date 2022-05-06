using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    //Flock agentsFlock

    private Collider2D _agentCollider;
    public Collider2D AgentCollider { get => _agentCollider; }

    // Start is called before the first frame update
    void Start() => _agentCollider = GetComponent<Collider2D>();
    
    public void Move(Vector2 velocity)
    {
        transform.up = velocity.normalized; //Rotate the AI
        transform.position += (Vector3)velocity * Time.deltaTime; //Move the AI
    }
   
}
