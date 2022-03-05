using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance = null;
    public static Music Instance {
        get { return instance; }
    }
    // private AudioSource _audioSource;
    // private GameObject[] other;
    // private bool NotFirst = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        // other = GameObject.FindGameObjectWithTag("Music");

        // foreach (GameObject oneOther in other)
        // {
        //     if (oneOther.scene.buildIndex == -1)
        //     {
        //         NotFirst = true;
        //     }
        // }

        // if (NotFirst == true)
        // {
        //     Destroy(gameObject);
        // }

        // DontDestroyOnLoad(transform.gameObject);
        // _audioSource = GetComponent<AudioSource>();
    }

    // public void PlayMusic()
    // {
    //     if (_audioSource.isPlaying) return;
    //     _audioSource.Play();
    // }

    // public void StopMusic()
    // {
    //     _audioSource.Stop();
    // }
}
