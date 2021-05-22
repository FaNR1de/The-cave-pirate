using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkins : MonoBehaviour
{
    public SpriteRenderer hat;
    public SpriteRenderer body, rightHand, leftHand, rightFoot, leftFoot, flag;
    public int index;
    [SerializeField] private Sprite[] bodysprite, hatsprite, rightHandsprite, leftHandsprite, rightFootsprite, leftFootsprite, flagSprite;
    
    private void Awake()
    {
        index = PlayerPrefs.GetInt("index");
    }
    void Start()
    {
        
        hat = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        body = transform.GetChild(0).GetComponent<SpriteRenderer>();
        rightHand = transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>();
        leftHand = transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>();
        rightFoot = transform.GetChild(1).GetComponent<SpriteRenderer>();
        leftFoot = transform.GetChild(2).GetComponent<SpriteRenderer>();
        flag = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        index = PlayerPrefs.GetInt("index");
        UpdateSkin(index); 
    }
    public void UpdateSkin(int index)
    {
        
        hat.sprite = hatsprite[index];
        body.sprite = bodysprite[index];
        rightHand.sprite = rightHandsprite[index];
        leftHand.sprite = leftHandsprite[index];
        rightFoot.sprite = rightFootsprite[index];
        leftFoot.sprite = leftFootsprite[index];
        flag.sprite = flagSprite[index];
    }


    
}