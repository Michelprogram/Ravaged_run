using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;


public class Menu : MonoBehaviour
{

    #region UI Menu
    private Button play, settings, exit;

    public GameObject gameScreen;
    #endregion

    #region UI Settings
    private Button back;

    public ToggleGroup keyboard;

    public GameObject settingsScreen;

    public Slider volume;
    public Text valueVolume;

    #endregion

    #region UI Difficulty
    public TMP_Dropdown difficulty;

    private Button start;

    public GameObject difficultyScreen;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Find our buttons in scene
        InitButtons();

        //Hide screens
        settingsScreen.SetActive(false);
        difficultyScreen.SetActive(false);

        volume.onValueChanged.AddListener(UpdateVolume);

        //Add event for each buttons
        EventButtons();
    }

    private void InitButtons()
    {
        //Game
        play = GameObject.Find("Play").GetComponent<Button>();
        settings = GameObject.Find("Settings").GetComponent<Button>();
        exit = GameObject.Find("Exit").GetComponent<Button>();

        //Settings
        back = GameObject.Find("Back").GetComponent<Button>();

        //Difficulty
        start = GameObject.Find("Start").GetComponent<Button>();
    }

    private void EventButtons()
    {
        //Game
        play.onClick.AddListener(SwapMenuDifficulty);
        settings.onClick.AddListener(SwapMenuSettings);
        exit.onClick.AddListener(ExitGame);

        //Settings
        back.onClick.AddListener(SwapMenuSettings);

        //Difficulty
        start.onClick.AddListener(GoToGame);

    }

    private void UpdateVolume(float value)
    {
        AudioListener.volume = value;
        valueVolume.text = value+"";
    }

    private void SwapMenuSettings()
    {
        ToggleMenu();
        ToggleSettings();
    }

    private void SwapMenuDifficulty()
    {
        ToggleMenu();
        ToggleDifficulty();
    }

    private void GoToGame()
    {
        Debug.Log(GetSelectedToggle().name);
        Debug.Log(difficulty.value);
        

        //SceneManager.LoadScene(1);
    }

    private void ToggleSettings()
    {
        var active = settingsScreen.activeInHierarchy;
        settingsScreen.SetActive(!active);
    }

    private void ToggleMenu()
    {
        var active = gameScreen.activeInHierarchy;
        gameScreen.SetActive(!active);
    }

    private void ToggleDifficulty()
    {
        var active = gameScreen.activeInHierarchy;
        difficultyScreen.SetActive(!active);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private Toggle GetSelectedToggle()
    {
        foreach(Toggle toggle in keyboard.GetComponentsInChildren<Toggle>())
        {
            if (toggle.isOn) return toggle;
        }

        return null;
    }
}
