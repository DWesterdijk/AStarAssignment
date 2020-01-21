using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was made by Duncan Westerdijk
/// 
/// ------------------------------------------
/// 
/// This is to make the directions of the hexagons easy accesible.
/// </summary>
public enum HexDirections
{
    NE, E, SE, SW, W, NW
}

public static class HexDirectionExtension
{
    public static HexDirections Opposite (this HexDirections direction) // This functions allows you to get the opposites of one side with the line: "Direction.Opposite(direction)"
    {
        return (int)direction < 3 ? (direction + 3) : (direction - 3);
    }
}
