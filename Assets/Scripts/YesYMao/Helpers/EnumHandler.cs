using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YesYMao.Helpers
{

    public enum CanvasType
    {
        Pregame,
        MainMenu,
        GameUI,
        EndScreen,
        VictoryScreen, 
        Credits, 
        PauseScreen,
        Options,
        OptionsMain
    }
    public enum ButtonType
    {
        Pregame,
        MainMenu,
        StartGame,
        Restart,
        Credits,
        Pause,
        Resume,
        Options,
        PregameCreds,
        OptionsMain,
        MainFromOptions
    }

    public enum GameState
    {
        Pregame, MainMenu, GamePlay, Paused, Victory, GameOver, Restart
    }

}