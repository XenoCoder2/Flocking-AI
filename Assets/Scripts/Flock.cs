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


    


}
