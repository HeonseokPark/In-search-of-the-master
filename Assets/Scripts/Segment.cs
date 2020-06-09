using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public int SegId
    {
        set;
        get;
    }

    public bool Transition;

    public int Lenght;
    public int BeginY1, BeginY2, BeginY3;
    public int EndY1, EndY2, EndY3;

    private Piece[] Pieces;

    private void Awake()
    {
        Pieces = gameObject.GetComponentsInChildren<Piece>();
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
    }

    public void DeSpawn()
    {
        gameObject.SetActive(false);
    }
}
