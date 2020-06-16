using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance
    {
        set;
        get;
    }

    public List<Piece> Ramps = new List<Piece>();
    public List<Piece> LongBlocks = new List<Piece>();
    public List<Piece> Jumps = new List<Piece>();
    public List<Piece> Slides = new List<Piece>();
    public List<Piece> Pieces = new List<Piece>();


    public Piece GetPiece(PieceType type, int VisualIndex)
    {
        Piece piece = Pieces.Find(x =>
            x.type == type && x.VisualIndex == VisualIndex && x.gameObject.activeSelf == false);
        if (piece == null)
        {
            GameObject GO = null;
            if (type == PieceType.Ramp)
            {
                GO = Ramps[VisualIndex].gameObject;
            }
            else if (type == PieceType.LongBlock)
            {
                GO = LongBlocks[VisualIndex].gameObject;
            }
            else if (type == PieceType.Jump)
            {
                GO = Jumps[VisualIndex].gameObject;
            }
            else if (type == PieceType.Slide)
            {
                GO = Slides[VisualIndex].gameObject;
            }

            GO = Instantiate(GO);
            piece = GO.GetComponent<Piece>();
        }
        
        return piece;
    }
}
