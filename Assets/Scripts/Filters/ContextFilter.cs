using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ContextFilter : ScriptableObject
{
    #region Filter
    //Create an abstract method for other filters that inherit from this script.
    public abstract List<Transform> Filter(FlockAgent agent, List<Transform> original);
    #endregion
}
