using System.Collections;
using System.Collections.Generic;
using Pathing;
using UnityEngine;

/// <summary>
/// This script was made by Duncan Westerdijk
/// 
/// ------------------------------------------
/// 
/// In here I inherit the functions from IAStarNode.cs and fill in the functions to return the right values to make the AStar pathfinding work.
/// </summary>
public class AStarInherit : MonoBehaviour, IAStarNode
{
    public IEnumerable<IAStarNode> Neighbours
    {
        get
        {
            List<AStarInherit> neighbours = new List<AStarInherit>();
            for (int i = 0; i < GetComponentInChildren<CellManager>()._neighbours.Length; i++)
            {
                if (GetComponentInChildren<CellManager>()._neighbours[i] != null && GetComponentInChildren<CellManager>()._neighbours[i].GetComponent<HexWeight>().weight < 4)
                    neighbours.Add(GetComponentInChildren<CellManager>()._neighbours[i].GetComponentInParent<AStarInherit>());
            }
            return neighbours;
        }
    }

    public float CostTo(IAStarNode neighbour)
    {
        AStarInherit neigh = (AStarInherit)neighbour;
        return (this.GetComponent<HexWeight>().weight + neigh.GetComponent<HexWeight>().weight) / 2;
    }

    public float EstimatedCostTo(IAStarNode goal)
    {
        AStarInherit aStarInh = (AStarInherit)goal;
        return Mathf.Abs(this.transform.position.x - aStarInh.transform.position.x) + Mathf.Abs(this.transform.position.y - aStarInh.transform.position.y);
    }
}
