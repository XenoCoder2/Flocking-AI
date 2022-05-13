using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]
public class AvoidanceBehaviour : FlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        Vector2 avoidanceMove = Vector2.zero;

        int count = 0;
        foreach (Transform t in context)
        {
            //if (Vector2.SqrMagnitude(t.position - agent.transform.position) <= flock.SquareAvoidanceRadius)
            //{
            avoidanceMove += (Vector2)(agent.transform.position - t.position);
            count++;
            //}
        }
        if (count != 0)
        {
            avoidanceMove /= count;
        }

 
        return avoidanceMove;
    }
}
