using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YesYMao.Helpers;
using UnityEngine.SceneManagement;
namespace YesYMao.Managers
{

    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] Camera initialCamera;
        GameState currentGameState = GameState.MainMenu;
        SceneManagement sceneManager;
        AudioListener mainCameraListener;
        void Start()
        {
            sceneManager = SceneManagement.GetInstance();
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
                    try
                    {
                        sceneManager.UnloadLevel("MemoryGame");
                    }
                    catch (System.Exception)
                    {
                        //sceneManager.StartGame();
                        return;
                    }
                    //sceneManager.StartGame();
                    
                    sceneManager.ResetGame();
                    initialCamera.gameObject.SetActive(true);

                    break;
                case GameState.GamePlay:
                    
                    initialCamera.gameObject.SetActive(false);
                    sceneManager.LoadLevel("MemoryGame");
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
                    //UnloadLevel("MemoryGame");
                    Scene current = SceneManager.GetActiveScene();
                    
                    sceneManager.UnloadLevel(current.name, 1);
                    // currentGameState = GameState.GamePlay;
                    break;


            }
        }

        public void UnloadLevel(string levelName)
        {
            Debug.Log("manolo");
            AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
            if (ao == null)
            {
                Debug.LogError("[GameManager] unable to load level: " + levelName);
                return;
            }
            ao.completed += OnUnloadOperationComplete;
        }

        void OnUnloadOperationComplete(AsyncOperation ao)
        {
            Debug.Log("Unloaded!");
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("MemoryGame"));
            // firstMovement = true;
            // firstShift = true;
            // StopAllCoroutines();
            
            Debug.Log("unloaded completed");
            // Notify life bar to replenish again
            // Reset loot values
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