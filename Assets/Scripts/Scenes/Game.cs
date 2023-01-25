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
    #endregion

    #region UI Dead

    public GameObject deadScreen;
    #endregion

    #region UI Win

    public GameObject winScreen;
    public Button back;
    #endregion


    private UnityEvent dead;

    // Use this for initialization
    void Start()
	{

        dead = new UnityEvent();

        InitScreen();
        InitText();

        //Events
        Shared.arrival.AddListener(WinScreen);
        Shared.obstacle.AddListener(LostLife);
        Shared.start.AddListener(StartRun);

        dead.AddListener(DeadScreen);

        //Buttons
        back.onClick.AddListener(ReturnMenu);
	}

	// Update is called once per frame
	void Update()
	{
    }

    private void InitScreen()
    {
        pauseScreen.SetActive(false);
        deadScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    private void InitText()
    {
        //Game
        life.text = "Life : "+Shared.GetLifeStr();
        level.text = Shared.GetDifficultyStr();

    }

    private void WinScreen()
    {
        Utils.ToggleCanvas(winScreen);
        Utils.ToggleCanvas(gameScreen);

        Shared.SetPause(true);
    }

    private void DeadScreen()
    {
        Utils.ToggleCanvas(deadScreen);
        Utils.ToggleCanvas(gameScreen);

        Shared.SetPause(true);
    }

    private void LostLife()
    {
        var hp = Shared.GetLife() - 1;

        if (hp == 0)
        {
            dead.Invoke();
        }
        else
        {
            Shared.SetLife(hp);
            life.text = "Life : " + Shared.GetLife();
        }
    }

    private void StartRun()
    {
        Debug.Log("start");
    }

    private void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

}

