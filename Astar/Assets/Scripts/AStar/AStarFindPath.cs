using System.Collections;
using System.Collections.Generic;
using Pathing;
using UnityEngine;

/// <summary>
/// This script was made by Duncan Westerdijk
/// 
/// ------------------------------------------
/// 
/// This script will look for a path using the functions in the given scripts.
/// </summary>
public class AStarFindPath : MonoBehaviour
{
    [SerializeField]
    private CellList _CellList;
    [SerializeField]
    private GenerateGrid _genGrid;

    [SerializeField]
    private CellManager[] _neighbours;

    public IList<IAStarNode> path;

    private void Update()
    {
        //With this big If statement I check if both list contain an object, in order to do so I check for if both start and end lists are empty, or if one is empty. once both contain an item we continue.
        if (_CellList.startCell.Count == 0 && _CellList.endCell.Count == 0 || _CellList.startCell.Count != 0 && _CellList.endCell.Count == 0 || _CellList.startCell.Count == 0 && _CellList.endCell.Count != 0)
        {
            //do nothing
            Debug.Log("One or Two cells not yet selected");
            Debug.Log("Please select a start point and an end point;");
        }
        else
        {
            //This is to only let this happen once and not every frame, else it would get messy and lag up really quick.
            if (path == null || path.Count == 0)
            {
                path = AStar.GetPath(_CellList.startCell[0].GetComponent<AStarInherit>(), _CellList.endCell[0].GetComponent<AStarInherit>());
                Debug.Log("Attemting to find path...");
                Debug.Log("Please wait...");
                SetPath(path);
            }
        }
    }

    private void SetPath(IList<IAStarNode> path)
    {
        for (int i = 0; i < path.Count; i++)
        {
            AStarInherit cell = (AStarInherit)path[i];
            if (cell.GetComponent<Renderer>().material.color == Color.white) //this small if statement is mainly to make sure that the Start cell and End cell stay their original given colour.
                cell.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
