using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{
    public GameObject[] Resource;
    public GameObject Anim1;
    public int RandomRes;
    public int x;

    // Start is called before the first frame update
    void Start()
    {
        Anim();
    }

    public void Anim()
    {
        RandomRes = Random.Range(0, Resource.Length);
        
        Resource[RandomRes].SetActive(false);
        Instantiate(Anim1, Resource[RandomRes].transform.position, Anim1.transform.rotation);

        StartCoroutine(Respawn(RandomRes));
    }

    IEnumerator Respawn(int x)
    {

        yield return new WaitForSeconds(3);
        x = RandomRes;
        StartCoroutine(Waiter(x));
        Anim();
       
    
    }


    IEnumerator Waiter(int x)
    {
        yield return new WaitForSeconds(2);
        Resource[x].SetActive(true);
    }

}
