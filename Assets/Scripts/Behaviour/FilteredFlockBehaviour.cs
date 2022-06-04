using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the FilteredFlock behaviour.
[CreateAssetMenu(menuName = "Flock/Behaviour/FilteredFlock")]
public abstract class FilteredFlockBehaviour : FlockBehaviour
{
    #region Variable
    //The filter to be used for the flock behaviour.
    public ContextFilter filter;
    #endregion

}
