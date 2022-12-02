using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
        
    public int Id { get; set;}

    [SerializeField] private SpriteRenderer m_SpriteRenderer;

    public void OnMouseDown()
    {
        print(Id);
    }
}
