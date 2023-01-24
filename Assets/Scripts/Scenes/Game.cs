using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    #region UI Game

    public GameObject gameScreen;
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

    private int dodge;

    // Use this for initialization
    void Start()
	{
        InitScreen();
        InitButtons();

        dodge = 1;

        //Events
        Shared.arrival.AddListener(WinScreen);
        Shared.obstacle.AddListener(LostDodge);

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

    private void InitButtons()
    {
        //Win
    }

    private void WinScreen()
    {
        Utils.ToggleCanvas(winScreen);
        Utils.ToggleCanvas(gameScreen);
    }

    private void LostDodge()
    {
        dodge--;
    }

    private void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

}

