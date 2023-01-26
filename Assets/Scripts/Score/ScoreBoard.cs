using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour
{
	public GameObject panel, line;

    private ScoreManager scoreManager;
	// Use this for initialization
	void Start()
	{
        scoreManager = new ScoreManager();

        GetScore();

        Shared.score.AddListener(GetScore);
    }

    //Display score
    public void GetScore()
	{
        
        CleanScroll();

        var scores = scoreManager.Read();

        foreach (Score score in scores)
        {
            var tempo = GameObject.Instantiate(line, panel.transform);
            SetTextInLine(tempo, score);
        }
    }

    //Set each text with value
    private void SetTextInLine(GameObject line, Score score)
	{
        var texts = line.GetComponentsInChildren<Text>();

		texts[0].text = score.GetName();
        texts[1].text = score.GetPoint();
        texts[2].text = score.GetTime();
        texts[3].text = score.GetDifficulty();
    }

    //Remove all childs from panel
    private void CleanScroll()
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }

}

