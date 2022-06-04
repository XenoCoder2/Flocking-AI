using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehaviour : ScriptableObject
{
    #region Calculate Move
    //An abstract class to be used by inheriting classes.
    public abstract Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock);
    #endregion
}
