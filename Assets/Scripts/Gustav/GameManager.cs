using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameBoard m_GameBoard;

    private bool m_CanTakeCard = true;
    private Card m_LastSelection = null;

    private void Awake()
    {
        Singleton();
        m_GameBoard = GetComponent<GameBoard>();
    }

    
    // Start is called before the first frame update
    void Start()
    {
        m_GameBoard.InitializeBoard();
    }

    public void ClickOnCard(Card card)
    {
        if (!m_CanTakeCard)
            return;

        if (!m_LastSelection)
        {
            //Si no es la última carta seleccionada, entonces esta es la primera que giramos.
            FirstSelectedCard(card);
        }
        else
        {
            //Si ya hay una carta seleccionada, por tanto esta es la segunda carta girada.
            SecondSelectedCard(card);
        }
    }

    private void FirstSelectedCard(Card card)
    {

    }

    private void SecondSelectedCard(Card card)
    {

    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
