using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RandomMusicPlayer : MonoBehaviour
{

    private string folderPath;

    private AudioSource audio;

    private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {

        var audioPath = RandomAudio();

        audio = GetComponent<AudioSource>();

        clip = GenerateClip(audioPath);

        SetClip();
       
        audio.Play();
    }

    private string RandomAudio() {

        string[] filePaths = Directory.GetFiles(folderPath);

        int index = Random.Range(0, filePaths.Length);

        return filePaths[index];
    }

    /*
     * Set Audio clip
     */
    private AudioClip GenerateClip(string path)
    {
        return AudioClip.Create(Path.GetFileNameWithoutExtension(path), (int)new FileInfo(path).Length, 1, 44100, false);
    }

    /*
     * Set Audio to the attribute
     */
    private void SetClip()
    {
        audio.clip = clip;
    }
}
