using UnityEngine;
using System.Collections;

public class Music1 : MonoBehaviour
{

    public AudioSource Mus;

    public static Music1 instance = null;

    // Use this for initialization
    void Start()
    {
        if (instance != null)
        {
            Destroy(Mus);
            Debug.Log("One Music Destroyed");
            return;
        }
        instance = this;
        DontDestroyOnLoad(Mus);
        //if(GlobalOptions.isSound()){
        Mus.Play();
        //}
    }

    public void Pause()
    {
        Mus.Pause();
    }

    public void Play()
    {
        Mus.Play();
    }
}