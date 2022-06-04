using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the SameFlock filter.
[CreateAssetMenu(menuName = "Flock/Filters/SameFlock")]
public class SameFlockFilter : ContextFilter
{
    #region Filter
    public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
    {
        //Create a filtered list.
        List<Transform> filtered = new List<Transform>();

        //For each of the items in the original list.
        foreach (Transform item in original)
        {
            //Get the FlockAgent script from the item.
            FlockAgent itemAgent = item.GetComponent<FlockAgent>();

            //If itemAgent is not equal to null.
            if (itemAgent != null)
            {
                //If the itemAgent's flock is the same as the agent's flock.
                if (itemAgent.AgentFlock == agent.AgentFlock)
                {
                    //Add the itemAgent to the filtered list.
                    filtered.Add(item);
                }
            }
        }

        //Return the filtered list.
        return filtered;
    }
    #endregion
}
