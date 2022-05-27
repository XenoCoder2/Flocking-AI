using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/FilteredFlock")]
public abstract class FilteredFlockBehaviour : FlockBehaviour
{
    public ContextFilter filter;

}
