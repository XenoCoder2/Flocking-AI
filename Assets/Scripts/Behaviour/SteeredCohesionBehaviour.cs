using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the SteeredCohesion behaviour.
[CreateAssetMenu(menuName = "Flock/Behaviour/SteeredCohesion")]
public class SteeredCohesionBehaviour : CohesionBehaviour
{
    #region Variables
    //A Vector2 to get the current velocity.
    private Vector2 _currentVelocity;
    //The smooth time for the agent.
    public float agentSmoothTime = 0.5f;
    #endregion

    #region CalculateMove
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //Create a Vector2 called cohesionMove which is equal to the value from the inherited CalculateMove method.
        Vector2 cohesionMove = base.CalculateMove(agent, context, flock);
       
        //Smooth out the cohesionMove variable.
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref _currentVelocity, agentSmoothTime);

        //Return the cohesionMove Vector2.
        return cohesionMove;
    }
    #endregion

}
