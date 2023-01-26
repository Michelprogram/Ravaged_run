using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    #region UI Game

    public GameObject gameScreen;

    public Text life, score, time, level;
    #endregion

    #region UI Pause

    public GameObject pauseScreen;
    public Button returnGame;
    #endregion

    #region UI Dead

    public GameObject deadScreen;
    public Button backDead;
    #endregion

    #region UI Win

    public GameObject winScreen;
    public Button backWin;
    #endregion


    private UnityEvent dead;
    private float startTimer, scoreFactor;

    private int computedLife;

    public GameObject pseudo;

    public AudioSource roblox;

    // Use this for initialization
    void Start()
	{
        startTimer = 0;
        computedLife = 0;
        dead = new UnityEvent();

        InitScreen();
        InitVariableByDifficulty();
        InitText();

        //Events
        Shared.arrival.AddListener(WinScreen);
        Shared.obstacle.AddListener(LostLife);
        Shared.start.AddListener(StartRun);

        dead.AddListener(DeadScreen);

        //Buttons
        backWin.onClick.AddListener(ReturnMenu);
        backDead.onClick.AddListener(ReturnMenu);

        returnGame.onClick.AddListener(ReturnGame);

    }

	// Update is called once per frame
	void Update()
	{

        if (startTimer > 0 && !Shared.GetPause())
        {
            time.text = "Time : " + ComputedTimer();
            score.text = "Score : " + ComputedScore();
        }
 
        if (Input.GetKey(KeyCode.Escape))
        {
            DisplayPause();
        }
    }

    //Init score factor
    private void InitVariableByDifficulty()
    {
        switch (Shared.GetDifficulty())
        {
            default:
            case Shared.Difficulty.Easy:
                scoreFactor = 0.005f;
                computedLife = 3;
                break;
            case Shared.Difficulty.Normal:
                scoreFactor = 0.006f;
                computedLife = 2;
                break;
            case Shared.Difficulty.Hard:
                scoreFactor = 0.007f;
                computedLife = 2;
                break;
            case Shared.Difficulty.Xtrem:
                scoreFactor = 0.01f;
                computedLife = 1;
                break;

        }
    }

    //Hide pause, dead and win screen
    private void InitScreen()
    {
        pauseScreen.SetActive(false);
        deadScreen.SetActive(false);
        winScreen.SetActive(false);

        pseudo.SetActive(false);
    }

    //In pause screen return to the game
    private void ReturnGame()
    {
        Utils.ToggleCanvas(gameScreen);
        Utils.ToggleCanvas(pauseScreen);

        Shared.SetPause(false);
    }

    //Display pause screen
    private void DisplayPause()
    {
        Utils.ToggleCanvas(gameScreen);
        Utils.ToggleCanvas(pauseScreen);

        Shared.SetPause(true);
    }

    //Init texts field
    private void InitText()
    {
        //Game
        life.text = "Life : " + computedLife;
        level.text = Shared.GetDifficultyStr();
    }

    //Display win screen
    private void WinScreen()
    {
        Utils.ToggleCanvas(winScreen);
        Utils.ToggleCanvas(gameScreen);
        Utils.ToggleCanvas(pseudo);

        Shared.SetPause(true);
        
    }

    //Display dead screen
    private void DeadScreen()
    {
        Utils.ToggleCanvas(deadScreen);
        Utils.ToggleCanvas(gameScreen);
        Utils.ToggleCanvas(pseudo);

        Shared.SetPause(true);
    }

    //Reduce one hp by one
    private void LostLife()
    {
        roblox.Play();
        computedLife--;
        if (computedLife == 0)
        {
            dead.Invoke();
        }
        else
        {
            life.text = "Life : " + computedLife;
        }
    }

    //Init timer when green is passed
    private void StartRun()
    {
        startTimer = Time.deltaTime;
    }

    //Change scene
    private void ReturnMenu()
    {
        SaveScore();

        SceneManager.LoadScene(0);
    }

    //Computed timer
    private string ComputedTimer()
    {
        startTimer += Time.deltaTime;
        return startTimer.ToString("F2");
    }

    //Computed Score
    private string ComputedScore()
    {
        Shared.scoreTotal += (1 * scoreFactor);

        return Shared.scoreTotal.ToString("F1");
    }

    //Save score to json file
    private void SaveScore()
    {
        var name = pseudo.GetComponent<TMP_InputField>().text.ToString();

        if (name == "")
        {
            name = "John Doe";
        }

        var sc = new Score(name, Shared.scoreTotal.ToString("F1"), Shared.GetDifficulty(), startTimer.ToString("F2"));

        new ScoreManager().SaveScore(sc);
    }
}

