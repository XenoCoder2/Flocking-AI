using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Require a Collider2D.
[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    #region Variables
    //This is the flock the agent belongs to
    Flock _agentsFlock;
    //A property to get the flock of the agent.
    public Flock AgentFlock { get => _agentsFlock; }

    //The collider of the agent.
    private Collider2D _agentCollider;
    //A property to get the agent's collider.
    public Collider2D AgentCollider { get => _agentCollider; }
    #endregion

    #region Initialise
    public void Initialise(Flock flock)
    {
        //Initialise the agent into it's appropriate flock.
        _agentsFlock = flock;
    }
    #endregion

    #region Start Method
    //At the start, get the Collider2D from the agent.
    void Start() => _agentCollider = GetComponent<Collider2D>();
    #endregion

    #region Move Method
    public void Move(Vector2 velocity)
    {
        transform.up = velocity.normalized; //Rotate the AI
        transform.position += (Vector3)velocity * Time.deltaTime; //Move the AI
    }
    #endregion

    #region On Destroy Method
    private void OnDestroy()
    {
        //For all the agents in the agents flock.
        for (int i = 0; i < _agentsFlock.agents.Count; i++)
        {
            //If the currently iterated agent is this agent.
            if (_agentsFlock.agents[i] == this)
            {
                //Remove the agent.
                _agentsFlock.agents.RemoveAt(i);
                //Break out of the for loop.
                break;
            }
        }
    }
    #endregion
}
