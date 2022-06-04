using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the Avoidance behaviour.
[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]
public class AvoidanceBehaviour : FilteredFlockBehaviour
{
    #region Calculate Move
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //If the context count is equal to 0.
        if (context.Count == 0)
        {
            //Return (0,0,0).
            return Vector2.zero;
        }

        //Create a Vector2 called avoidanceMove.
        Vector2 avoidanceMove = Vector2.zero;
        //Create a list called filteredContext and evaluate whether or not the behaviour is filtered.
        List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);
        //Create an int called count which is equal to 0.
        int count = 0;
        //For each of the transforms in filteredContext.
        foreach (Transform t in filteredContext)
        {
            //If the square magnitude of the current transform minused by the agent's current position is less than or equal the flock's square avoidance radius.
            if (Vector2.SqrMagnitude(t.position - agent.transform.position) <= flock.SquareAvoidanceRadius)
            {
                //Add the agent's transform minused by the current transform to avoidanceMove.
                avoidanceMove += (Vector2)(agent.transform.position - t.position);
                //Increase count by 1.
                count++;
            }
        }
        //If the count is not equal to 0.
        if (count != 0)
        {
            //Divide avoidanceMove by count.
            avoidanceMove /= count;
        }

        //Return the avoidanceMove Vector2.
        return avoidanceMove;
    }
    #endregion
}
