using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] mus;
    public AudioSource source1;
    public float dlina;
    public int number;
    
    void Start()
    {
        number = Random.Range(0, mus.Length);
        source1.clip = mus[number];
        dlina = mus[number].length;
        source1.Play();
        StartCoroutine(Waiter(dlina));
        
    }

    IEnumerator Waiter(float x)
    {
        yield return new WaitForSeconds(x);
        Start();
    }
}
