using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSetter : MonoBehaviour
{
    [SerializeField] GameObject[] cards = new GameObject[16];
    [SerializeField] int separation = 3;
    [SerializeField] int boardSize = 4;
    Vector3 offset = Vector3.zero;


    void Start()
    {
        Vector3 positionToMove = transform.position;  
        Debug.Log(positionToMove);
        int counter = 1;
        int secondCounter = 0;
        int multiplier = 1;
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position =  (new Vector3( (i) % (counter),  (secondCounter %( i + 1)) * -1, 0) * separation) + offset;
            counter++;
            if (counter % (boardSize + 1) == 0)
            {
                counter += 1;
                offset = new Vector3( -(separation*boardSize * multiplier) , 0, 0);
                multiplier++;
            }
            if ((i+1) % boardSize == 0)
                secondCounter++;
        }
    }
}
