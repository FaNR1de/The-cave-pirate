using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFAQ : MonoBehaviour
{
    public GameObject FAQ;

    public void Open()
    {
        FAQ.SetActive(true);
    }
    public void Close()
    {
        FAQ.SetActive(false);
    }
}
