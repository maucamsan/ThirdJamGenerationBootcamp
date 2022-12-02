using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    
    [Header("Values")]
    //Game Area
    [SerializeField] int m_GameAreaX = 6;
    [SerializeField] int m_GameAreay = 6;

    //Separation between cards
    [SerializeField] Vector2 m_SpacingBetweenCards = Vector2.zero;

    [Header("References")]
    [SerializeField] GameObject m_Card;
    [SerializeField] Transform m_GameArea;


    void Start()
    {
        for(int x=0; x < m_GameAreaX; x++)
        {
            for(int y=0; y < m_GameAreay; y++)
            {
                GameObject cardGO = Instantiate(m_Card); //Instanciamos las cartas en cardGO
                cardGO.transform.SetParent(m_GameArea); //Lo incluimos en el área de juego que es su padre
                cardGO.transform.localPosition = new Vector3(x * m_SpacingBetweenCards.x, 0, y * m_SpacingBetweenCards.y);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
