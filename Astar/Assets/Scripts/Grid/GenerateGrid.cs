using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was made by Duncan Westerdijk
/// 
/// ------------------------------------------
/// 
/// In this script I generate the entire grid using a Vector2 instead of using two ints to define X and Y.
/// In this script I also give each cell it's material/terrain, and it's weight.
/// </summary>
public class GenerateGrid : MonoBehaviour
{
    [Header("Gridsize")]
    public Vector2 gridSize;

    [Header("Prefab")]
    public CellManager hexCell;

    [Header("Grid List")]
    public List<GameObject> gridList;

    [Header("")]
    [SerializeField]
    private List<Material> _matList;
    //A list of all the materials in the order of: Grass(1 day), Forrest(3 days), Desert(5 days), Mountain(10 days), Water(unable to travel).

    private CellManager[] cells;

    void Awake()
    {
        cells = new CellManager[(int)gridSize.x * (int)gridSize.y];
        for (int z = 0, i = 0; z < (int)gridSize.y; z++)
        {
            for (int x = 0; x < (int)gridSize.x; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexagonInformation.innerRad);
        position.y = 0f;
        position.z = z * (HexagonInformation.outerRad - 0.25f);

        int r = Random.Range(0, 5);

        CellManager cell = cells[i] = Instantiate(hexCell);
        cell.GetComponent<Renderer>().material = _matList[r];
        cell.GetComponent<Renderer>().material.color = Color.white;
        cell.GetComponent<HexWeight>().weight = r;

        //This little part of code sets the neighbours of each cell while generating the grid
        if (x > 0)
        {
            cell.SetNeighbour(HexDirections.W, cells[i - 1]); //The neighbour west and east of the cell.
        }
        if (z > 0)
        {
            if ((z & 1) == 0)
            {
                cell.SetNeighbour(HexDirections.SE, cells[i - (int)gridSize.x]); //The neighbour south-east of the cell.
                if (x > 0)
                {
                    cell.SetNeighbour(HexDirections.SW, cells[i - (int)gridSize.x - 1]);
                }
            }
            else
            {
                cell.SetNeighbour(HexDirections.SW, cells[i - (int)gridSize.x]);
                if (x < (int)gridSize.x - 1)
                {
                    cell.SetNeighbour(HexDirections.SE, cells[i - (int)gridSize.x + 1]);
                }
            }
        }

        cell.transform.SetParent(transform, false); //I make the cells a child object of the GameManager object for a cleaner inspector in Unity.
        cell.transform.localPosition = position;
        cell.name = x + ", " + z; //I give each cell it's corrposponding coördinations as its name for easier debugging purposes.
        gridList.Add(cell.gameObject);
    }
}
