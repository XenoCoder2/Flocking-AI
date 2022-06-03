using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject configPanel;
    public Text[] inputSize;
    public Text fireText;
    public Animator menuAnim;
    [SerializeField] Slider[] _sliders;
    [SerializeField] Flock[] _flocks;
    [SerializeField] Player _player;
    public static bool paused;
    private int _number;
    private Slider _tempSlider;
    public float orangeSize;
    public float greenSize;
    public float fireRate;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Saved"))
        {
            SaveOptions.ReadSettings(this);

            _sliders[0].value = orangeSize;
            _sliders[1].value = greenSize;
            _sliders[2].value = fireRate;

            inputSize[0].text = orangeSize.ToString();
            inputSize[1].text = greenSize.ToString();

            if (fireRate <= 0.10f)
            {
                fireText.text = "Fast";
            }
            else if (fireRate <= 0.20f && fireRate != 0.10f)
            {
                fireText.text = "Medium";
            }
            else if (fireRate >= 0.21f)
            {
                fireText.text = "Slow";
            }

            _flocks[0].startingCount = (int)orangeSize;
            _flocks[1].startingCount = (int)greenSize;
            _player.fireRate = fireRate;
            _player.resetFireRate = fireRate;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !configPanel.activeInHierarchy)
        {
            if (!pausePanel.activeInHierarchy)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                menuAnim.SetBool("Hidden", false);
                paused = true;
            }
            else
            {
                Time.timeScale = 1;
                menuAnim.SetBool("Hidden", true);
                paused = false;
            }
        }
    }

    public void Save()
    {
        PlayerPrefs.SetString("Saved", "");
        PlayerPrefs.Save();
        orangeSize = _sliders[0].value;
        greenSize = _sliders[1].value;
        fireRate = _sliders[2].value;

        SaveOptions.SaveSettings(this);
        configPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void FlockNumber(int num)
    {
        _number = num;
    }

    public void ChangeToOptions()
    {
        menuAnim.SetBool("Hidden", true);
    }

    public void StartingFlockSize(float size)
    {
        _flocks[_number].startingCount = Mathf.Max((int)size, 1);
        inputSize[_number].text = size.ToString();

        if (_number == 0)
        {
            orangeSize = Mathf.Max((int)size, 1);
        }
        else
        {
            greenSize = Mathf.Max((int)size, 1);
        }
    }

    public void FireRate(float rate)
    {
        _player.fireRate = rate;

        if (rate <= 0.10f)
        {
            fireText.text = "Fast";
        }
        else if (rate <= 0.20f && rate != 0.10f)
        {
            fireText.text = "Medium";
        }
        else if (rate >= 0.21f)
        {
            fireText.text = "Slow";
        }

        fireRate = rate;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        paused = false;
        menuAnim.SetBool("Hidden", true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        paused = !paused;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
