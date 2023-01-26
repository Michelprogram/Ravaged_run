using System.Linq;
using System.IO;
using UnityEngine;

public class RandomMusicPlayer : MonoBehaviour
{

    private AudioClip clip;

    public AudioClip[] songs;

    //Two song and choosed randomly
    void Start()
    {
        var audio = GetComponent<AudioSource>();

        int index = Random.Range(0, songs.Length);

        audio.clip = songs[index];
       
        audio.Play();
    }

    //Keep song between scene
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
