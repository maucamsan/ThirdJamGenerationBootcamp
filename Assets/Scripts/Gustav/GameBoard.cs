using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    
    [Header("Values")]
    //Game Area
    [SerializeField] int m_GameAreaX = 5;
    [SerializeField] int m_GameAreaY = 5;

    //Separation between cards
    [SerializeField] Vector2 m_SpacingBetweenCards = Vector2.zero;

    [Header("References")]
    [SerializeField] GameObject m_Card;
    [SerializeField] Transform m_GameArea;

    [SerializeField] private Sprite[] m_Images;


    public void InitializeBoard()
    {
        Vector2 initialPositionCard = CalculateInitialPositionCard();

        int numberOfCards = m_GameAreaX * m_GameAreaY;

        List<int> idsCards = CreateRandomList(numberOfCards);

        int createdCards = 0;

        for(int x=0; x < m_GameAreaX; x++)
        {
            for(int y=0; y < m_GameAreaY; y++)
            {
                GameObject cardGO = Instantiate(m_Card); //Instanciamos las cartas en cardGO
                cardGO.transform.SetParent(m_GameArea); //Lo incluimos en el área de juego que es su padre

                Card actualCard = cardGO.GetComponent<Card>();
                actualCard.Id = idsCards[createdCards];
               actualCard.SetImage(m_Images[actualCard.Id]);

                float posX = (x * m_SpacingBetweenCards.x) - initialPositionCard.x;
                float posY = (y * m_SpacingBetweenCards.y) - initialPositionCard.y;

                cardGO.transform.localPosition = new Vector3(posX, 0, posY);

                createdCards++;

            }
        }
    }


    private Vector2 CalculateInitialPositionCard()
    {
        float maximumPositionX = (m_GameAreaX - 1) * m_SpacingBetweenCards.x;
        float maximumPositionY = (m_GameAreaY - 1) * m_SpacingBetweenCards.y;
        float halfMaxPosX = maximumPositionX / 2;
        float halfMaxPosY = maximumPositionY / 2;
        return new Vector2(halfMaxPosX, halfMaxPosY);
    }

    private List<int> CreateRandomList(int numberOfCards)
    {
        List<int> idsCards = new List<int>(); 

        for (int i=0; i < numberOfCards; i++)
        {
            idsCards.Add(i / 2);
        }

        idsCards.Shuffle();

        return idsCards;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
