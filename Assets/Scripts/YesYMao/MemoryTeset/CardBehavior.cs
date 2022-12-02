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
    }
    // Start is called before the first frame update
    void Start()
    {
        id = cardData.id;
    }
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
        if (isClickable)
        {
            OnCardClicked?.Invoke(this);
            isClickable = false;
        }
    }

}
