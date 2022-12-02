using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSetter : MonoBehaviour
{
    [SerializeField] GameObject[] cards = new GameObject[16];
    List<int> cardsIdsList = new List<int>();
    [SerializeField] List<CardData> cardsDataList = new List<CardData>();
    [SerializeField] int separation = 3;
    [SerializeField] int boardSize = 4;
    Vector3 offset = Vector3.zero;
    
    int cardsIdsCount = 8;
    void Start()
    {
        

        List<int> idsShuffle = SetIds(cardsIdsCount);
        int numberOfCards = cards.Length;
        for (int i = 0; i < cardsDataList.Count; i++)
        {
            cardsDataList[i].id = idsShuffle[i % ((numberOfCards/2) - 1)];
        }


        SetTable();
        

    }

    void SetTable()
    {
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

    List<int> SetIds(int cardsIdsCount)
    {
        for (int i = 0; i < cardsIdsCount; i++)
        {
            cardsIdsList.Add(i);
        }
        cardsIdsList.Shuffle();
        return cardsIdsList;
    }
}

public static class IListExtensions {
  
    public static void Shuffle<T>(this IList<T> ts) {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
 
