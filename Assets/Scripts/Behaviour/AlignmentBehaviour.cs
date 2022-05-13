using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if(context.Count == 0)
        {
            return agent.transform.up;
        }

        Vector2 alignmentMove = Vector2.zero;
        int count = 0;

        foreach (Transform t in context)
        {
            alignmentMove += (Vector2)t.transform.up;
            count++;
        }

        if (count != 0)
        {
            alignmentMove /= count;
        }

        return alignmentMove;
    }
    
}
