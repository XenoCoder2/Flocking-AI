using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the Alignment behaviour.
[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FilteredFlockBehaviour
{
    #region Calculate Move
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //If the context count is equal to 0.
        if(context.Count == 0)
        {
            //Return the agent's transform. 
            return agent.transform.up;
        }

        //Create a Vector2 called alignmentMove.
        Vector2 alignmentMove = Vector2.zero;
        //Create a list called filteredContext and evaluate if there is a filter on this behaviour.
        List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);
        //Create an int called count and set it to 0.
        int count = 0;
        //For each of the transforms in filteredContext.
        foreach (Transform t in filteredContext)
        {
            //Add the up transform direction of the current transform to alignmentMove.
            alignmentMove += (Vector2)t.transform.up;
            //Increase count by 1.
            count++;
        }
        //If count is not equal to 0.
        if (count != 0)
        {
            //Divide alignmentMove by count.
            alignmentMove /= count;
        }

        //Return the alignmentMove Vector2.
        return alignmentMove;
    }
    #endregion
}
