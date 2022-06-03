using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnim : MonoBehaviour
{
    public GameObject pausePanel;

    public void HidePanel()
    {
        pausePanel.SetActive(false);
    }
}
