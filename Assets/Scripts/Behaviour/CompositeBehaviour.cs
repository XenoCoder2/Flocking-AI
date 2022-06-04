using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the behaviour.
[CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]
public class CompositeBehaviour : FlockBehaviour
{
    #region Variables / Struct
    //Serialise the struct.
    [System.Serializable]
    public struct BehaviourGroup
    {
        //A behaviour of the flock.
        public FlockBehaviour behaviour;
        //The weight of the flock.
        public float weights; 
    }

    //An array of the behaviours.
    public BehaviourGroup[] behaviours;
    #endregion

    #region Calculate Move
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //Create a temporary Vector2 called move.
        Vector2 move = Vector2.zero;

        //For each behaviour.
        foreach (BehaviourGroup b in behaviours)
        {
            //Create a new Vector2 called partialMove and evaluate the behaviours weights.
            Vector2 partialMove = b.behaviour.CalculateMove(agent, context, flock) * b.weights;

            //If partialMove is not equal to (0,0,0).
            if (partialMove != Vector2.zero)
            {
                //If the square magnitude of partialMove is greater than the weight multiplied by itself.
                if (partialMove.sqrMagnitude > b.weights * b.weights)
                {
                    //Normalise partialMove.
                    partialMove.Normalize();
                    //Multiply partialMove by the weight.
                    partialMove *= b.weights;
                }
            }

            //Increase move by partialMove's value.
            move += partialMove;
        }

        //Return move.
        return move;
    }
    #endregion
}
