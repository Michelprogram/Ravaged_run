using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class BackButton : MonoBehaviour
{
	public Button back;

	void Start()
	{
		back.onClick.AddListener(() => SceneManager.LoadScene(0));
	}

}

