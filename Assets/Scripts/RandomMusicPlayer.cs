using System.Linq;
using System.IO;
using UnityEngine;

public class RandomMusicPlayer : MonoBehaviour
{

    private AudioClip clip;

    public AudioClip[] songs;

    void Start()
    {
        var audio = GetComponent<AudioSource>();

        int index = Random.Range(0, songs.Length);

        audio.clip = songs[index];
       
        audio.Play();
    }

}
