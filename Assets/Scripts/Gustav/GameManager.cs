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
        m_LastSelection = card;
        card.ShowCardFront();
    }

    private void SecondSelectedCard(Card card)
    {
        if (card == m_LastSelection)
            return;
        card.ShowCardFront();

        if(card.Id == m_LastSelection.Id)
        {
            MatchedCard(card, m_LastSelection);
        }
        else
        {
            NotMatchedCard(card, m_LastSelection);
        }
    }

    private void MatchedCard(Card card, Card m_LastSelection)
    {
        // print("par correcto");
        //1. Destruir cards
        Destroy(card.gameObject, 1.5f);
        Destroy(m_LastSelection.gameObject, 1.5f);

        //2. Emitir particulas de acierto

        //3. Emitir sonido de acierto

        //4. Resetear LastSelection
        m_LastSelection = null;

        //5. Bloquear selección por cierto tiempo
        StartCoroutine(LockSelectionByTime(1.5f));

        //6. Descontar fichas del tablero para ganar
        m_GameBoard.m_RemainingCards -= 2;

        //7. Comprobar victoria
        if(m_GameBoard.m_RemainingCards <= 0)
        {
            //Ganamos el juego
        }
    }

    private void NotMatchedCard(Card card, Card m_LastSelection)
    {
       // print("par incorrecto");
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

    IEnumerator LockSelectionByTime(float time)
    {
        m_CanTakeCard = false;
        yield return new WaitForSeconds(time);
        m_CanTakeCard = true;
    }
}
