using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CardsManager : MonoBehaviour
{
    public static Action<bool> OnHandleClick;
    int id1;
    int id2;
    GameObject card1;
    GameObject card2;
    bool isFirst = true;
    Animator cardAnimator;
    Animator cardAnimator2;
    void OnEnable()
    {
        CardBehavior.OnCardClicked += ManageCards;
    }

    void OnDisable()
    {
        CardBehavior.OnCardClicked -= ManageCards;
    }

    void ManageCards(CardBehavior card)
    {
        if (isFirst)
        {   
            id1 = card.Id;
            card1 = card.gameObject;
            cardAnimator = card.gameObject.GetComponent<Animator>();
            cardAnimator.ResetTrigger("FlipLeftUI");
            cardAnimator.SetTrigger("FlipRightUI");
            isFirst = false;
        }
        else
        {
            id2 = card.Id;
            card2 = card.gameObject;
            
            cardAnimator2 = card.gameObject.GetComponent<Animator>();
            cardAnimator2.ResetTrigger("FlipLeftUI");
            cardAnimator2.SetTrigger("FlipRightUI");
            isFirst = true;
            StartCoroutine(WaitForAnimation());
        }
    }

    IEnumerator WaitForAnimation()
    {
        OnHandleClick?.Invoke(false);
        yield return new WaitForSeconds(1f);
        // if (id1 == id2)
        // {
        //     card1.SetActive(false);
        //     card2.SetActive(false);
        //     // Call Score manager
        // }
        if(id1 != id2)
        {
            cardAnimator.ResetTrigger("FlipRightUI");
            cardAnimator2.ResetTrigger("FlipRightUI");
            cardAnimator.SetTrigger("FlipLeftUI");
            cardAnimator2.SetTrigger("FlipLeftUI");
        }
        OnHandleClick?.Invoke(true);
    }

}
