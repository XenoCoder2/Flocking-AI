using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    //The flocks used.
    public Flock[] flockCount;
    //A panel to indicate the flocks have been destroyed.
    public GameObject levelFinishPanel;
    #endregion

    #region Update Method
    // Update is called once per frame
    void Update()
    {
        //If there are no more agents.
        if (flockCount[0].agents.Count < 1 && flockCount[1].agents.Count < 1)
        {
            //Activate the levelFinishPanel.
            levelFinishPanel.SetActive(true);
            //Set the state to paused.
            MenuHandler.paused = true;
        }
    }
    #endregion
}
