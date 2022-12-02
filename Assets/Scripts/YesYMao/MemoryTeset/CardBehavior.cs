using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CardBehavior : MonoBehaviour
{
    public static Action<CardBehavior> OnCardClicked;
    [SerializeField] CardData cardData;
    private int id;
    bool isClickable = true;
    
    public int Id
    {
        get{return id;}
        set{id = value;}
    }
    // Start is called before the first frame update
   
    void OnEnable()
    {
        CardsManager.OnHandleClick += SetClickable;
    }
    void OnDisable()
    {
        CardsManager.OnHandleClick -= SetClickable;
    }
    
    void SetClickable(bool clickable)
    {
        isClickable = clickable;
    }
    void OnMouseDown()
    {
        Debug.Log(Id);
        if (isClickable)
        {
            OnCardClicked?.Invoke(this);
            isClickable = false;
        }
    }

}
