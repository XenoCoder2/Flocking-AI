using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnim : MonoBehaviour
{
    #region Variable
    //The pausePanel GameObject.
    public GameObject pausePanel;
    #endregion

    #region Hide Panel
    public void HidePanel()
    {
        //Disable the pausePanel.
        pausePanel.SetActive(false);

        //This is used for the animation method for a smoother transition.
    }
    #endregion
}
