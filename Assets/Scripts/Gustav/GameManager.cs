using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using YesYMao.Helpers;
public class GameManager : MonoBehaviour
{
    public static Action OnCardsClicked;
    public static GameManager instance;
    private GameBoard m_GameBoard;

    

    private bool m_CanTakeCard = true;
    private Card m_LastSelection = null;

    [SerializeField] private int m_AttemptsRemaining = 10;

    [Header("Particles")]
    [SerializeField] ParticleEmitter particlesEmitter;

    [Header("Sounds")]
    [SerializeField] AudioSource m_SoundFX;
    [SerializeField] AudioClip m_MatchedSound;
    [SerializeField] AudioClip m_FailSound;
    private int counter = 0;

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
            //Si no es la �ltima carta seleccionada, entonces esta es la primera que giramos.
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

    private void MatchedCard(Card card, Card lastSelection)
    {
        // print("par correcto");
        //1. Destruir cards
        counter++;
        Destroy(card.gameObject, 1.5f);
        Destroy(lastSelection.gameObject, 1.5f);
        OnCardsClicked?.Invoke();
        //2. Emitir sonido de acierto
        if (m_MatchedSound != null)
        {
            m_SoundFX.PlayOneShot(m_MatchedSound);
        }

        //3. Emitir particulas de acierto
        particlesEmitter.EmitParticlesOnHit(card.transform);
        particlesEmitter.EmitParticlesOnHit(lastSelection.transform);

        //4. Resetear LastSelection
        m_LastSelection = null;

        //5. Bloquear selecci�n por cierto tiempo
        StartCoroutine(LockSelectionByTime(1.5f));

        //6. Descontar fichas del tablero para ganar
        m_GameBoard.m_RemainingCards -= 2;

        //7. Comprobar victoria
        if(m_GameBoard.m_RemainingCards <= 0)
        {
            YesYMao.Managers.UIManager.GetInstance().SwitchCanvas(CanvasType.Credits);
        }
    }

    private void NotMatchedCard(Card card, Card lastSelection)
    {
        // print("par incorrecto");
        //1. Deshacer la selecci�n
        m_LastSelection = null;

        //2. Disminuir intentos
        m_AttemptsRemaining -= 1;
        OnCardsClicked?.Invoke();
        //3. Emitir sonido de error en emparejamiento
        if(m_FailSound != null)
        {
            m_SoundFX.PlayOneShot(m_FailSound);
        }
        

        //4. Checar si la partida finalizo porque perdi� el jugador
        if (m_AttemptsRemaining <= 0)
        {
            m_CanTakeCard = false;
            //TODO Mostrar menu de GameOver
        }
        else
        {
            card.Invoke("ShowCardBack", 1.5f);
            lastSelection.Invoke("ShowCardBack", 1.5f);
            StartCoroutine(LockSelectionByTime(1.5f));
        }

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
