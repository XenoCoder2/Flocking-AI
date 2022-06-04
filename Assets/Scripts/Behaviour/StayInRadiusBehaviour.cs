using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the StayInRadius behaviour.
[CreateAssetMenu(menuName = "Flock/Behaviour/StayInRadius")]
public class StayInRadiusBehaviour : FlockBehaviour
{
    #region Variables
    //A Vector2 for the center of the radius.
    [SerializeField] private Vector2 _center;
    //A float to determine the radius size.
    [SerializeField] private float _radius = 15f;
    #endregion

    #region Calculate Move
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //direction to the center
        Vector2 centerOffset = _center - (Vector2)agent.transform.position;

        //Create a float called t which is equal to the magnitude of centerOffset divided by _radius.
        float t = centerOffset.magnitude / _radius;

        if (t < 0.9f) //If we are between the center and 90% of the radius
        {
            //Return (0,0).
            return Vector2.zero;
        }

        //Return the centerOffset multiplied twice by t.
        return centerOffset * t * t;
    }
    #endregion
}
