using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YesYMao.Helpers;
using YesYMao.Managers;
using UnityEngine.UI;

namespace YesYMao.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonController : MonoBehaviour
    {
        public ButtonType buttonType;

        UIManager canvasManager;
        Button menuButton;

        void Start()
        {
            menuButton = GetComponent<Button>();
            menuButton.onClick.AddListener(OnButtonClick);
            canvasManager = UIManager.GetInstance();
        }

        private void OnButtonClick()
        {
            switch(buttonType)
            {
                case ButtonType.Pregame:
                    canvasManager.SwitchCanvas(CanvasType.MainMenu);
                    break;
                case ButtonType.MainMenu:
                    canvasManager.SwitchCanvas(CanvasType.MainMenu);
                    break;
                case ButtonType.StartGame:
                    canvasManager.SwitchCanvas(CanvasType.GameUI);
                    break;
                case ButtonType.Credits:
                    canvasManager.SwitchCanvas(CanvasType.Credits);
                    break;
                case ButtonType.Pause:
                    canvasManager.SwitchCanvas(CanvasType.PauseScreen);
                    break;
                case ButtonType.Restart:
                    canvasManager.SwitchCanvas(CanvasType.Pregame);
                    break;
                case ButtonType.Resume:
                    canvasManager.SwitchCanvas(CanvasType.GameUI);
                    break;
                case ButtonType.Options:
                    canvasManager.SwitchCanvas(CanvasType.Options);
                    break;
                case ButtonType.PregameCreds:
                    canvasManager.SwitchCanvas(CanvasType.Pregame);
                    break;
                default:
                    break;
            }
        }
    }

}