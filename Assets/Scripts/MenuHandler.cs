using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    #region Variables
    //The pausePanel GameObject.
    public GameObject pausePanel;
    //The configPanel GameObject.
    public GameObject configPanel;
    //An array of text to show the flock slider values.
    public Text[] inputSize;
    //The text to show the fire rate value.
    public Text fireText;
    //The animator for the menu.
    public Animator menuAnim;
    //An array of the sliders in the options menu.
    [SerializeField] Slider[] _sliders;
    //An array of the flocks.
    [SerializeField] Flock[] _flocks;
    //The player script.
    [SerializeField] Player _player;
    //A bool to check if the game is paused.
    public static bool paused;
    //A number to determine what flock is being modified.
    private int _number;
    //A float to remember the orange flock starting count.
    public float orangeSize;
    //A float to remember the green flock starting count.
    public float greenSize;
    //A float to remember the player fire rate.
    public float fireRate;
    //A reference to the Game Manager.
    private GameManager _manage;
    #endregion

    #region Start
    private void Start()
    {
        //Get the Game Manager component.
        _manage = GetComponent<GameManager>();
        //Set paused to false.
        paused = false;
        //If the player has saved before.
        if (PlayerPrefs.HasKey("Saved"))
        {
            //Read the settings with this MenuHandler as the input.
            SaveOptions.ReadSettings(this);

            //Set the Orange flocks starting count to the value from orange size converted to an int.
            _flocks[0].startingCount = (int)orangeSize;
            //Set the Green flocks starting count to the value from green size converted to an int.
            _flocks[1].startingCount = (int)greenSize;

            //Set the slider values to the floats read from the config text.
            _sliders[0].value = orangeSize;
            _sliders[1].value = greenSize;
            _sliders[2].value = fireRate;
            //Set the text to the value from the floats read from the config text.
            inputSize[0].text = orangeSize.ToString();
            inputSize[1].text = greenSize.ToString();

            //If the fireRate is less than or equal to 0.10f. 
            if (fireRate <= 0.10f)
            {
                //Set the fireText to "Fast".
                fireText.text = "Fast";
            }
            //If the fireRate is less than or equal to 0.20f but is not equal to 0.10f. 
            else if (fireRate <= 0.20f && fireRate != 0.10f)
            {
                //Set the fireText to "Medium".
                fireText.text = "Medium";
            }
            //Else if the fireRate is greater than or equal to 0.21f.
            else if (fireRate >= 0.21f)
            {
                //Set the fireText to "Slow".
                fireText.text = "Slow";
            }

            //Set the player's fire rate to the fireRate value.
            _player.fireRate = fireRate;
            //Set the player's reset fire rate to the fireRate value.
            _player.resetFireRate = fireRate;
        }

        _flocks[0].SpawnFlock();
        _flocks[1].SpawnFlock();

    }
    #endregion

    #region Update
    // Update is called once per frame
    void Update()
    {
        //If the escape key was pressed and the config panel is not active.
        if (Input.GetKeyDown(KeyCode.Escape) && !configPanel.activeInHierarchy && !_manage.levelFinishPanel.activeInHierarchy)
        {
            //If the pausePanel is not active.
            if (!pausePanel.activeInHierarchy)
            {
                //Pause in-game time.
                Time.timeScale = 0;
                //Activate the pausePanel.
                pausePanel.SetActive(true);
                //Set the Hidden bool to false for the animator.
                menuAnim.SetBool("Hidden", false);
                //Set paused to true.
                paused = true;
            }
            //Else the pausePanel is active.
            else
            {
                //Resume in-game time.
                Time.timeScale = 1;
                //Set the Hidden bool to true for the animator.
                menuAnim.SetBool("Hidden", true);
                //Set paused to false.
                paused = false;
            }
        }
    }
    #endregion

    #region Save
    public void Save()
    {
        //Create a Saved string.
        PlayerPrefs.SetString("Saved", "");
        //Run the Save method from PlayerPrefs.
        PlayerPrefs.Save();
        //Set orangeSize to the slider value.
        orangeSize = _sliders[0].value;
        //Set greenSize to the slider value.
        greenSize = _sliders[1].value;
        //Set fireRate to the slider value.
        fireRate = _sliders[2].value;

        //Run the SaveSettings method with this MenuHandler as the input.
        SaveOptions.SaveSettings(this);
        //Disable the configPanel.
        configPanel.SetActive(false);
        //Enable the pausePanel.
        pausePanel.SetActive(true);
    }
    #endregion

    #region Config Settings

    #region Flock Number
    public void FlockNumber(int num)
    {
        //Set _number to num. 
        _number = num;
    }
    #endregion

    #region Starting Flock Size
    public void StartingFlockSize(float size)
    {
        //Set the flocks starting count to the value from the slider.
        _flocks[_number].startingCount = Mathf.Max((int)size, 1);
        //Update the text to reflect the value.
        inputSize[_number].text = size.ToString();

        //If the number is equal to 0.
        if (_number == 0)
        {
            //Set the orangeSize to the size input.
            orangeSize = Mathf.Max((int)size, 1);
        }
        //Else
        else
        {
            //Set the greenSize to the size input.
            greenSize = Mathf.Max((int)size, 1);
        }
    }
    #endregion

    #region Fire Rate
    public void FireRate(float rate)
    {
        //Set the player's fireRate to the rate input from the slider.
        _player.fireRate = rate;

        //If the fireRate is less than or equal to 0.10f. 
        if (rate <= 0.10f)
        {
            //Set the fireText to "Fast".
            fireText.text = "Fast";
        }
        //If the fireRate is less than or equal to 0.20f but is not equal to 0.10f. 
        else if (rate <= 0.20f && rate != 0.10f)
        {
            //Set the fireText to "Medium".
            fireText.text = "Medium";
        }
        //Else if the rate is greater than or equal to 0.21f.
        else if (rate >= 0.21f)
        {
            //Set the fireText to "Slow".
            fireText.text = "Slow";
        }

        fireRate = rate;
    }
    #endregion

    #endregion

    #region Pause Menu Methods
    public void Resume()
    {
        //Resume in-game time.
        Time.timeScale = 1;
        //Set paused to false.
        paused = false;
        //Set the Hidden bool to false.
        menuAnim.SetBool("Hidden", true);
    }

    #region Change To Options
    public void ChangeToOptions()
    {
        //Set the Hidden bool of the animator to true.
        menuAnim.SetBool("Hidden", true);
    }
    #endregion

    public void Restart()
    {
        //Resume in-game time.
        Time.timeScale = 1;
        //Set paused to false.
        paused = false;
        //Reload the current scene.
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        //If in the Unity Editor.
#if UNITY_EDITOR
        //Stop playing.
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        //Quit the Application.
        Application.Quit();
    }
    #endregion
}
