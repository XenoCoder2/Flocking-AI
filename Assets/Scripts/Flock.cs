using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    #region Variables
    //A list of all the agents in a flock. 
    public List<FlockAgent> agents;
    //The prefab for the agents.
    public FlockAgent agentPrefab;
    //The behaviour of the flock. 
    public FlockBehaviour behaviour;
    //A range for the starting count of the flock.
    [Range(10, 500)]
    public int startingCount = 250;
    //A constant float to dictate the density of the agents.
    const float _agentDensity = 0.08f;
    //A range for the drive factor of the agents.
    [Range(1f, 100f)]
    public float driveFactor = 10f;
    //A range used to determine the speed of the agents in the flock.
    [Range(1, 100f)]
    public float maxSpeed = 5f;
    //A range used to determine the radius between neighbours in a flock.
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;
    //A multiplier to calculate the avoidance radius of the flock.
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    //The max speed multiplied by itself.
    float _squareMaxSpeed;
    //The neighbour radius multiplied by itself.
    float _squareNeighbourRadius;
    //The avoidance radius multiplied by itself.
    float _squareAvoidanceRadius;

    //A property to get the square avoidance radius.
    public float SquareAvoidanceRadius {get { return _squareAvoidanceRadius; } }
    #endregion

    #region Start
    private void Start()
    {
        //_squareMaxSpeed is equal to maxSpeed multiplied by itself.
        _squareMaxSpeed = maxSpeed * maxSpeed;
        //_squareNeighbourRadius is equal to neighbourRadius multiplied by itself.
        _squareNeighbourRadius = neighbourRadius * neighbourRadius;
        //_squareAvoidanceRadius is equal to the _squareNeighbourRaidus multiplied by the avoidanceRadiusMultiplier which is multiplied by itself.
        _squareAvoidanceRadius = _squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
    }
    #endregion

    #region Spawn Flock
    public void SpawnFlock()
    {
        //For the starting count of the flock.
        for (int i = 0; i < startingCount; i++)
        {
            //Instantiate a new agent into the flock.
            FlockAgent newAgent = Instantiate( //Creates a clone of gameObject prefab
                agentPrefab, //The prefab to spawn in
                Random.insideUnitCircle * startingCount * _agentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0, 360f)),
                transform
                );
            //Name the agent with an increasing value.
            newAgent.name = "Agent_" + i;
            //Initialise the agent into the flock.
            newAgent.Initialise(this);
            //Add the agent into the agents list.
            agents.Add(newAgent);
        }
    }
    #endregion

    #region Update
    private void Update()
    {
        //Foreach of the agents in the agents list.
        foreach (FlockAgent agent in agents)
        {
            //Create a list called context and get the nearby objects close to the currently iterated agent.
            List<Transform> context = GetNearbyObjects(agent);

            //FOR TESTING
            //agent.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.blue, context.Count / 6f);

            //Create a Vector2 called move which is equal to the value from the chosen behaviours CalculateMove method.
            Vector2 move = behaviour.CalculateMove(agent, context, this);
            //Multiply the move value by the driveFactor.
            move *= driveFactor;
            //If the square magnitude of move is greater than _squareMaxSpeed.
            if (move.sqrMagnitude > _squareMaxSpeed)
            {
                //Make move equal to the normalised value of itself multiplied by maxSpeed.
                move = move.normalized * maxSpeed;
            }

            //Run the move method on the agent.
            agent.Move(move);
        }
    }
    #endregion

    #region GetNearbyObjects Method
    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        //Create a temporary list called context. 
        List<Transform> context = new List<Transform>();
        //Create a Collider2D array called contextColliders to grab agent colliders.
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
        //Foreach of the colliders in the contextColliders list.
        foreach (Collider2D c in contextColliders)
        {
            //If the collider is not the agents own collider.
            if (c != agent.AgentCollider)
            {
                //Add it to the context list.
                context.Add(c.transform);
            }
        }

        //Return the context list.
        return context;
    }
    #endregion

}
