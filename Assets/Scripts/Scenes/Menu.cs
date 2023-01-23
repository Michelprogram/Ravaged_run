using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    #region UI Menu
    private Button play, settings, exit;

    public GameObject gameScreen;
    #endregion

    #region UI Settings
    private Button back;

    public GameObject settingsScreen;

    public Slider volume;
    public Text valueVolume;

    //Keyboard touch
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Find our buttons in scene
        InitButtons();

        //Hide settings screen
        settingsScreen.SetActive(false);

        volume.onValueChanged.AddListener(UpdateVolume);

        //Add event for each buttons
        EventButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitButtons()
    {
        //Game
        play = GameObject.Find("Play").GetComponent<Button>();
        settings = GameObject.Find("Settings").GetComponent<Button>();
        exit = GameObject.Find("Exit").GetComponent<Button>();

        //Settings
        back = GameObject.Find("Back").GetComponent<Button>();
    }

    private void EventButtons()
    {
        //Game
        play.onClick.AddListener(GoToGame);
        settings.onClick.AddListener(SwapMenu);
        exit.onClick.AddListener(ExitGame);

        //Settings
        back.onClick.AddListener(SwapMenu);
    }

    private void UpdateVolume(float value)
    {
        AudioListener.volume = value;
        valueVolume.text = value+"";
    }

    private void SwapMenu()
    {
        ToggleMenu();
        ToggleSettings();
    }

    private void GoToGame()
    {
        SceneManager.LoadScene(1);
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

    private void ExitGame()
    {
        Application.Quit();
    }
}
