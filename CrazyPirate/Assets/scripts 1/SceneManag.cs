using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManag : MonoBehaviour
{

    private Animator anim;
    public int levelToLoad;

    
    

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();

    }
    public void FadeToLevel()
    {
        anim.SetTrigger("fade");
    }
   
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
