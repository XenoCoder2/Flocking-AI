using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the filter.
[CreateAssetMenu(menuName = "Flock/Filters/Layer")]
public class LayerFilter : ContextFilter
{
    #region Variable
    //A LayerMask variable to get a chosen layer.
    public LayerMask mask;
    #endregion

    #region Filter
    public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
    {
        //Create a filtered list.
        List<Transform> filtered = new List<Transform>();
        //For each item in the orignal list.
        foreach(Transform item in original)
        {
            //1      = 000000000000000001
            //1 << 6 = 000000000001000000
            //mask   = 000101010001010010
           
            //If the item's layer is the mask layer.
            if(0 != (mask & (1 << item.gameObject.layer)))
            {
                //Add the item to the filtered list.
                filtered.Add(item);
            }
        }

        //Return the filtered list.
        return filtered;
    }
    #endregion
}
