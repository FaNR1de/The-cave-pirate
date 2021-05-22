using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    int number = 0;
    public GameObject[] Resource;
    public Vector3 PosEnd;
    public GameObject Cam;
    public Vector3 ResPos;
    public Vector3 ResPosEnd;
    
   

    
    public void ClickHome()
    {
        if (number <= 14)
        {
            Active();
        } else SceneManager.LoadScene("MainMenu"); 

    }
    void Active()
    {
        StartCoroutine(Waiter());
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(0.15f);
        Resource[number].SetActive(true);
        
        number++;
        ClickHome();
    }
   
    
}
