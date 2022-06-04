using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the filter.
[CreateAssetMenu(menuName = "Flock/Filters/DifferentFlock")]
public class DifferentFlockFilter : ContextFilter
{
    #region Filter 
    public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
    {
        //Create a filtered list.
        List<Transform> filtered = new List<Transform>();

        //For each item in the original list.
        foreach (Transform item in original)
        {
            //Set itemAgent to the flockAgent from item.
            FlockAgent itemAgent = item.GetComponent<FlockAgent>();
            //If the itemAgent is not null.
            if (itemAgent != null)
            {
                //If the itemAgent's flock is not equal to the agent's flock.
                if (itemAgent.AgentFlock != agent.AgentFlock)
                {
                    //Add the item to the filtered list.
                    filtered.Add(item);
                }
            }
        }

        //Return the filtered list.
        return filtered;
    }
    #endregion
}
