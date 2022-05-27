using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public List<FlockAgent> agents;

    public FlockAgent agentPrefab;

    public FlockBehaviour behaviour;

    [Range(10, 500)]
    public int startingCount = 250;
    const float _agentDensity = 0.08f;
    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float _squareMaxSpeed;
    float _squareNeighbourRadius;
    float _squareAvoidanceRadius;

    public float SquareAvoidanceRadius {get { return _squareAvoidanceRadius; } }

    private void Start()
    {
        _squareMaxSpeed = maxSpeed * maxSpeed;
        _squareNeighbourRadius = neighbourRadius * neighbourRadius;
        _squareAvoidanceRadius = _squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate( //Creates a clone of gameObject prefab
                agentPrefab, //The prefab to spawn in
                Random.insideUnitCircle * startingCount * _agentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0, 360f)),
                transform
                );
            newAgent.name = "Agent_" + i;
            newAgent.Initialise(this);
            agents.Add(newAgent);
        }
    }

    private void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            //FOR TESTING
            //agent.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.blue, context.Count / 6f);

            Vector2 move = behaviour.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > _squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }

            agent.Move(move);
        }
    }

    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
        foreach (Collider2D c in contextColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }

}
