using UnityEngine;
using System.Collections;

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
    #endregion

    // Use this for initialization
    void Start()
	{
        InitScreen();
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

}

