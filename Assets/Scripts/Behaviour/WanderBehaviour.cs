using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create an asset menu for the Wander Behaviour.
[CreateAssetMenu(menuName = "Flock/Behaviour/Wander")]
public class WanderBehaviour : FilteredFlockBehaviour
{
    #region Variables 
    //A variable to get the Path script. 
    private Path _path;
    //An int to determine the currently searched waypoint.
    private int _currentWaypoint = 0;
    #endregion

    #region Calculate Move
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //If the path is equal to null, run the PathFind method. 
        if (_path == null) PathFind(agent, context);

        //Return the FollowPath method with the agent as an input.
        return FollowPath(agent);
    }
    #endregion

    #region Follow Path
    private Vector2 FollowPath(FlockAgent agent)
    {
        //If the path is null return (0,0).
        if (_path == null) return Vector2.zero;

        //Create a Vector3 called waypointDirection.
        Vector3 waypointDirection;

        //If the value from the WaypointInRadius method returns true.
        if (WaypointInRadius(agent, _currentWaypoint, out waypointDirection))
        {
            //Increase _currentWaypoint by 1.
            _currentWaypoint++;
            //If _currentWaypoint is greater than or equal to the count of the _path waypoints.
            if (_currentWaypoint >= _path.waypoints.Count)
            {
                //Reset _currentWaypoint to 0.
                _currentWaypoint = 0;
            }

            //Return (0,0).
            return Vector2.zero;
        }

        //Return the waypointDirection normalised.
        return waypointDirection.normalized;

    }
    #endregion

    #region Waypoint In Radius
    public bool WaypointInRadius(FlockAgent agent, int currentWaypoint, out Vector3 waypointDirection)
    {
        //Set wayointDirection to the currently searched waypoints position minused by the agents position.
        waypointDirection = (Vector2)(_path.waypoints[currentWaypoint].position - agent.transform.position);

        //If the waypointDirection's magnitude is less than the path radius.
        if (waypointDirection.magnitude < _path.radius)
        {
            //Return a true bool.
            return true;
        }
        else
        {
            //Return a false bool.
            return false;
        }

    }
    #endregion

    #region Path Find
    private void PathFind(FlockAgent agent, List<Transform> context)
    {
        //Create a list called filteredContext and evaluate if this behaviour is filtered.
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        //If the count of filteredContext is equal to 0.
        if (filteredContext.Count == 0)
        {
            //Return.
            return;
        }
        //Create an int called randomPath which is equal to a random value from 0 to the count of filteredContext.
        int randomPath = Random.Range(0, filteredContext.Count);
        //Set the path to the randomPath.
        _path = filteredContext[randomPath].GetComponentInParent<Path>();
    }
    #endregion
}
