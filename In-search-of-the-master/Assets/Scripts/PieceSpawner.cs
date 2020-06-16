using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public PieceType Type;
    private Piece CurrentPiece;

    public void Spawn()
    {
        CurrentPiece = LevelManager.Instance.GetPiece(Type, 0);
        CurrentPiece.gameObject.SetActive(true);
        CurrentPiece.transform.SetParent(transform, false);
    }

    public void DeSpawn()
    {
        CurrentPiece.gameObject.SetActive(false);
    }
}
