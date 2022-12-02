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
            // public static Action OnGamePlayStarted;
            void OnStateChange()
            {

            }

            public void StartGame()
            {
                // LoadLevel("Main");
            }

            void ResetGame()
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

            public void UnloadLevel(string levelName)
            {
                AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
                if (ao == null)
                {
                    Debug.LogError("[GameManager] unable to load level: " + levelName);
                    return;
                }
                ao.completed += OnUnloadOperationComplete;
            }

            void OnLoadOperationComplete(AsyncOperation ao)
            {
                //controller.CanMove = false;
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("MemoryTest"));
                
            }
            void OnUnloadOperationComplete(AsyncOperation ao)
            {
                ResetGame();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));
                // firstMovement = true;
                // firstShift = true;
                // StopAllCoroutines();
                // currentGameState = GameState.Pregame;
                Debug.Log("unloaded completed");
                // Notify life bar to replenish again
                // Reset loot values
            }
    }

}