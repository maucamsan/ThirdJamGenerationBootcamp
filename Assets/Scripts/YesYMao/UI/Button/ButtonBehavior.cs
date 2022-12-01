using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using YesYMao.Managers;
namespace YesYMao.UI
{

    public class ButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bool hasObjectToAnim = false;
        [SerializeField] GameObject cardToAnim;
        Animator cardAnimator;
        
        void Awake()
        {
            if (hasObjectToAnim)
                cardAnimator = cardToAnim.GetComponent<Animator>();
            //DisableCard(true);
            
        }
        void OnEnable()
        {
            DisableCard(true);
        }

        void  OnDisable()
        {
            DisableCard(false);
            // SceneManagement.OnGamePlayStarted -= DisableCard;
        }

        void DisableCard(bool state)
        {
            if (hasObjectToAnim)
                cardToAnim.SetActive(state);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (hasObjectToAnim)
            {
                cardAnimator.ResetTrigger("FlipLeftUI");
                cardAnimator.SetTrigger("FlipRightUI");
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (hasObjectToAnim)
            {
                cardAnimator.ResetTrigger("FlipRightUI");
                cardAnimator.SetTrigger("FlipLeftUI");
            }
        }
    }

}