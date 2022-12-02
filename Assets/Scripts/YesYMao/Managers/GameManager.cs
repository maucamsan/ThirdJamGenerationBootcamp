using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YesYMao.Helpers;
namespace YesYMao.Managers
{

    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] Camera initialCamera;
        GameState currentGameState = GameState.MainMenu;
        AudioListener mainCameraListener;
        void Start()
        {
            //mainCameraListener = initialCamera.GetComponent<AudioListener>();
            UpdateState(currentGameState);

            //AudioManager.Instance.PlayMusic("BackgroundMusic");
        }

        void UpdateState(GameState state)
        {
            
            switch(currentGameState)
            {
                
                case GameState.MainMenu:
                    //Debug.Log("My current state is main menu");
                    // Don't let player move
                    // Set music accorgingly
                    // StartGame();
                    // UnPauseGame();
                    // ResetGame();
                    

                    break;
                case GameState.GamePlay:
                    // UnPauseGame();
                    // controller.CanMove = true;
                    // if (firstMovement)
                    // {
                    //     StartCoroutine(FirstMove());
                    // }
                    // Set gameplay music
                    // Allow player and game mechanics
                    SceneManagement.GetInstance().LoadLevel("MemoryTest");
                    initialCamera.gameObject.SetActive(false);
                    break;
                case GameState.Paused:
                    //PauseGame();
                    break;
                case GameState.Victory:
                    //ResetGame();
                    //PauseGame();
                    //canvasManager.SwitchCanvas(CanvasType.VictoryScreen);
                    // send to main menu
                    break;
                case GameState.GameOver:
                    //canvasManager.SwitchCanvas(CanvasType.EndScreen);
                    // Let restart
                    // Let send to main menu
                    //StopAllCoroutines();
                    // UnloadLevel("Main");
                    // OnGameOver?.Invoke();
                    // Controller2D c = FindObjectOfType<Controller2D>();
                    // c.CanMove = false;
                    
                    break;
                case GameState.Restart:
                    //UnloadLevel("Main");
                    
                    break;


            }
        }

        public GameState CurrentGamestate
        {
            get {return currentGameState;}
            set
            {
                currentGameState = value;
                UpdateState(currentGameState);
            }
        }
    }

}