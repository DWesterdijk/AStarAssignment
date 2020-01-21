using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was made by Duncan Westerdijk
/// 
/// ------------------------------------------
/// 
/// This script manages the neighbours of each cell.
/// </summary>
public class CellManager : MonoBehaviour
{
    public CellManager[] _neighbours;

    public CellManager GetNeighbour (HexDirections direction)
    {
        return _neighbours[(int)direction];
    }

    public void SetNeighbour (HexDirections direction, CellManager cell)
    {
        _neighbours[(int)direction] = cell;
        cell._neighbours[(int)direction.Opposite()] = this;
    }
}
