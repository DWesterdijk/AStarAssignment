using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was made by Duncan Westerdijk
/// 
/// ------------------------------------------
/// This script was to give the informations about the hexagon, to give all corners of the hexagon.
/// I ended up not using everything from this script and only ended up using the outerRad and innerRad for my generation.
/// </summary>
public static class HexagonInformation
{
    public const float outerRad = 1;
    public const float innerRad = outerRad * 0.8660254037844386f; //Inner radius = Outer radius * Sqrt(3)/2 (which is 0.8660254037844386)

    /// <summary>
    /// This function sets all the corners of the Hexagon mesh in an array for later use in making the grid.
    /// </summary>
    public static Vector3[] hexCorners =
    {
        new Vector3(0f, 0f, outerRad),
        new Vector3(innerRad, 0f, 0.5f * outerRad),
        new Vector3(innerRad, 0f, -0.5f * outerRad),
        new Vector3(0f, 0f, -outerRad),
        new Vector3(-innerRad, 0f, -0.5f * outerRad),
        new Vector3(-innerRad, 0f, 0.5f * outerRad)
    };
}
