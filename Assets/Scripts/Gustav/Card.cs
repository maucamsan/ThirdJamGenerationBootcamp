using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
        
    public int Id { get; set;}

    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private Animator m_Animator;

    public void OnMouseDown()
    {
        //print(Id);
        GameManager.instance.ClickOnCard(this);
    }

    public void ShowCardFront()
    {
        m_Animator.Play("ChangePositionBackToFrontCard");
    }

    public void ShowCardBack()
    {
        m_Animator.Play("ChangePositionFrontToBack");
    }

    public void SetImage(Sprite sprite)
    {
        m_SpriteRenderer.sprite = sprite;
    }
}
