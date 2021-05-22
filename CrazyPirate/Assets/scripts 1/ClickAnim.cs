using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnim : MonoBehaviour
{ 
    public Vector2 mousePos;
    public GameObject ClickAn;

    public void Click()
    {
        Instantiate(ClickAn, mousePos, ClickAn.transform.rotation);
    }


    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
