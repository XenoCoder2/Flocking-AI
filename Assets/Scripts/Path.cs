using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    #region Variables
    //A list of the waypoints.
    public List<Transform> waypoints;

    //The radius that a flock needs to be in to be declared at the waypoint.
    public float radius = 2.5f;

    //A gizmo to show the path.
    [SerializeField] private Vector3 _gizmoSize = Vector3.one;

    //A fill bool to toggle whether waypoints are added at start or not.
    public bool isFill = true;
    #endregion

    #region Start
    private void Start()
    {
        //Run the FillWithChildren method.
        FillWithChildren();
    }
    #endregion

    #region Fill With Children (Transforms)
    private void FillWithChildren()
    {
        //If isFill is false, return out of the method.
        if (!isFill) return;

        //For each of the transforms in the children objects of the GameObject that this script is attached to.
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            //If the transform is not already in the waypoints list.
            if (child != transform && !waypoints.Contains(child))
            {
                //Add the child transform to the waypoints list.
                waypoints.Add(child);
            }
        }

    }
    #endregion

    #region On Draw Gizmos
    private void OnDrawGizmos()
    {
        //If there are no waypoints, return.
        if (waypoints == null || waypoints.Count == 0)
        {
            return;
        }

        //Iterate for all the waypoints. 
        for (int i = 0; i < waypoints.Count; i++)
        {
            //Create a transform called waypoint which is equal to the currently iterated waypoint.
            Transform waypoint = waypoints[i];

            //If the waypoint is not null.
            if (waypoint == null)
            {
                //Continue the for loop.
                continue;
            }

            //Set the gizmos colour to cyan.
            Gizmos.color = Color.cyan;
            //Draw a cube at the waypoints position.
            Gizmos.DrawCube(waypoint.position, _gizmoSize);
            //Set the gizmos colour to magenta.
            Gizmos.color = Color.magenta;
            //If there is another waypoint after this waypoint.
            if (i + 1 < waypoints.Count && waypoints[i + 1] != null)
            {
                //Draw a line from the current waypoint to the next waypoint.
                Gizmos.DrawLine(waypoint.position, waypoints[i + 1].position);
            }
            //Else if it is the last waypoint.
            else if (i == waypoints.Count - 1)
            {
                //Draw a line from this waypoint to the first waypoint.
                Gizmos.DrawLine(waypoint.position, waypoints[0].position);
            }
        }
    }
    #endregion
}
