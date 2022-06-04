using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the Cohesion behaviour.
[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FilteredFlockBehaviour
{
    #region Calculate Move
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //If the context count is equal to 0.
        if (context.Count == 0)
        {
            //Return.
            return Vector2.zero;
        }

        //Create a Vector2 called cohesionMove.
        Vector2 cohesionMove = Vector2.zero;
        //Create a filtered list and determine of the behaviour is filtered.
        List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);
        //Create an int called count and set it to 0.
        int count = 0;
        //For each of the items in filteredContext.
        foreach(Transform t in filteredContext)
        {
            //Add the position of the current transform to cohesionMove.
            cohesionMove += (Vector2) t.position;
            //Increase count by 1.
            count++;
        }
        //If count is not equal to 0.
        if (count != 0)
        {
            //Divide cohesionMove by count.
            cohesionMove /= count;
        }

        //Direction from a to b = is b - a
        cohesionMove -= (Vector2) agent.transform.position;

        //Return the cohesionMove Vector2.
        return cohesionMove;
    }
    #endregion
}
