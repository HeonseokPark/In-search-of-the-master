using UnityEngine;

public enum PieceType
{
    None = -1,
    Ramp = 0,
    LongBlock = 1,
    Jump = 2,
    Slide = 3,
    
}

public class Piece : MonoBehaviour
{
    public PieceType type;
    public int VisualIndex;
}