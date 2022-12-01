using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YesYMao.Helpers;
using YesYMao.UI;
using System.Linq;
namespace YesYMao.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        private List<CanvasController> canvasControllerList;
        CanvasController lastActiveCanvas;
        Animator animator;

        protected override void Awake()
        {
            //base.Awake();
            canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
            canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
            SwitchCanvas(CanvasType.MainMenu);
        }
      
    
    
        public void SwitchCanvas(CanvasType type)
        {
            if (lastActiveCanvas != null)
                lastActiveCanvas.gameObject.SetActive(false);
            
            CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == type);

            if (desiredCanvas != null)
            {
                desiredCanvas.gameObject.SetActive(true);
                lastActiveCanvas = desiredCanvas;
            }
            else
                Debug.LogWarning("The main menu canvas was not found!");
        }

    
   
    }

}