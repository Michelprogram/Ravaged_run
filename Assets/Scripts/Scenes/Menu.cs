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
    public Button play, settings, exit;

    public GameObject gameScreen, scoreboard;
    #endregion

    #region UI Settings
    private Button back, resetScore;

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

        //Init Shared variables
        Shared.ResetVariable();

    }

    private void InitButtons()
    {
        /*
         * Ne marche avec le build
            play = GameObject.Find("Play").GetComponent<Button>();
            settings = GameObject.Find("Settings").GetComponent<Button>();
            exit = GameObject.Find("Exit").GetComponent<Button>();
        */

        //Settings
        back = GameObject.Find("Back").GetComponent<Button>();
        resetScore = GameObject.Find("ResetScore").GetComponent<Button>();

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
        resetScore.onClick.AddListener(ResetScore);

        //Difficulty
        start.onClick.AddListener(GoToGame);

    }

    //Remove score inside scrollbar
    private void ResetScore()
    {
        new ScoreManager().Reset();

        Shared.score.Invoke();
    }

    private void UpdateVolume(float value)
    {
        AudioListener.volume = value;
        valueVolume.text = value+"";
    }

    private void SwapMenuSettings()
    {
        Utils.ToggleCanvas(gameScreen);
        Utils.ToggleCanvas(settingsScreen);
    }

    private void SwapMenuDifficulty()
    {
        Utils.ToggleCanvas(gameScreen);
        Utils.ToggleCanvas(difficultyScreen);
    }

    //Set difficulty
    private void GoToGame()
    {
        var condition = GetSelectedToggle().name == "1";

        Shared.SetKeyboard(condition);

        switch (difficulty.value)
        {
            default:
            case 0:
                Shared.SetDifficulty(Shared.Difficulty.Easy);
                break;
            case 1:
                Shared.SetDifficulty(Shared.Difficulty.Normal);
                break;
            case 2:
                Shared.SetDifficulty(Shared.Difficulty.Hard);
                break;
            case 3:
                Shared.SetDifficulty(Shared.Difficulty.Xtrem);
                break;
        }

        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    //Find which level is selected
    private Toggle GetSelectedToggle()
    {
        foreach(Toggle toggle in keyboard.GetComponentsInChildren<Toggle>())
        {
            if (toggle.isOn) return toggle;
        }

        return null;
    }
}
