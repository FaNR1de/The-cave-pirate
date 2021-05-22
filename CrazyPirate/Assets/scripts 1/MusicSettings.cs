using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSettings : MonoBehaviour
{
    public Animator anim;
    
    public int BOOL = 0;

   private void Start()
    {
        
        BOOL = PlayerPrefs.GetInt("VOLUME");
        if (BOOL == 0)
        {
            anim.SetBool("MusOff", false);
            AudioListener.volume = 1;
        }
        else
        {
            anim.SetBool("MusOff", true);
            AudioListener.volume = 0;
        }
    }

    public void OffMus()
    {
        if (BOOL == 0)
        {
            anim.SetBool("MusOff", true);
            AudioListener.volume = 0;
            BOOL = 1;
            PlayerPrefs.SetInt("VOLUME", BOOL);
        }
        else
        {
            anim.SetBool("MusOff", false);
            AudioListener.volume = 1;
            BOOL = 0;
            PlayerPrefs.SetInt("VOLUME", BOOL);
        }
    }
}
