using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class ScoreManager
{
    private string jsonFile;

    public ScoreManager()
    {
        jsonFile = JsonFilePath();

        //Create file if is no't exist
        File.AppendAllText(jsonFile, "");
    }

    /**
	 * Get string path
	 */
    private string JsonFilePath()
    {
        return Application.persistentDataPath + "/scores.json";
    }

    /**
	 * Add score to json file
	 */
    public void SaveScore(Score score)
    {
        var actual = Read();

        actual.Add(score);

        var jsonStr = JsonConvert.SerializeObject(actual);

        Reset();

        File.AppendAllText(jsonFile, jsonStr);
    }

    /**
	 * Read all scores from json file
	 */
    public List<Score> Read()
    {
        var scores = new List<Score>();

        try
        {
            var content = File.ReadAllText(jsonFile);

            if (content == "") return new List<Score>();

            return JsonConvert.DeserializeObject<List<Score>>(content);

        }
        catch (FileNotFoundException e)
        {
            Debug.Log("File not found" + e);
        }

        return new List<Score>();
    }

    /**
	 * Affiche tous les scores
	 */
    public string Display()
    {
        var res = "";
        var scores = Read();

        foreach (Score score in scores)
        {
            res += score.ToString() + "\n";
        }

        return res;
    }

    /**
	 * Clean json file
	 */
    public void Reset()
    {
        try
        {
            File.WriteAllText(jsonFile, "");

        }
        catch (FileNotFoundException e)
        {
            Debug.Log("File not found : " + e);
        }
    }
}