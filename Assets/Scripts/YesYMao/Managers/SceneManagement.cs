using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YesYMao.Helpers;
using UnityEngine.SceneManagement;
using System;

namespace YesYMao.Managers
{
    public class SceneManagement : Singleton<SceneManagement>
    {
        YesYMao.Managers.GameManager gameManager;
        void Start()
        {
            gameManager = YesYMao.Managers.GameManager.GetInstance();
        }
        // public static Action OnGamePlayStarted;
        public void OnStateChange()
        {

        }

        public void StartGame()
        {
            //LoadLevel("MainScene");
        }

        public void ResetGame()
        {
            // Reset inventory
            // Reset hunger bar
            // Place player in initial position
            // Reset lootables
            // Reset enemies
            // OnLevelReset?.Invoke();
        }

        public void LoadLevel(string levelName)
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
            if (ao == null)
            {
                Debug.LogError("[GameManager] unable to load level: " + levelName);
                return;
            }
            ao.completed += OnLoadOperationComplete;
        }

        public void UnloadLevel(string levelName, int i = 0)
        {
            
            Debug.Log(i);
            AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            if (ao == null)
            {
                Debug.LogError("[GameManager] unable to load level: " + levelName);
                return;
            }
            if (i == 0)
                ao.completed += OnUnloadOperationComplete;
            else
                ao.completed += OnUnloadOperationComplete1;
            
        }


        void OnLoadOperationComplete(AsyncOperation ao)
        {
            //controller.CanMove = false;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("MemoryGame"));
            
        }
        void OnUnloadOperationComplete(AsyncOperation ao)
        {
            ResetGame();
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
            // firstMovement = true;
            // firstShift = true;
            // StopAllCoroutines();
            // currentGameState = GameState.Pregame;
            Debug.Log("unloaded completed");
            // Notify life bar to replenish again
            // Reset loot values
        }
        void OnUnloadOperationComplete1(AsyncOperation ao)
        {
            gameManager.CurrentGamestate = GameState.GamePlay;
            
            Debug.Log("unloaded completed");
            
        }
    }

}