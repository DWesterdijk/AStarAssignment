using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was made by Duncan Westerdijk
/// 
/// ------------------------------------------
/// 
/// This script is to get the start cell and end cell for the A* pathfinding
/// The cells get stored in two seperate lists in a seperate script (CellList)
/// 
/// This is to make it accesible in every script.
/// </summary>
public class AstarGetCell : MonoBehaviour
{
    public CellList cellList;
    public AStarFindPath path;

    [SerializeField]
    private bool _isLClicked;
    [SerializeField]
    private bool _isRClicked;

    private void Update()
    {
        OnClick();
    }

    private void OnClick()
    {
        //I have set the start cell on the Left Mouse button.
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Once the Raycast is pointed on an object, and if it is clicked it will check if no other start cell has been selected.
                if (_isLClicked == false)
                {
                    //If no other start cell is selected it will look if the asked cell's weight is lower than 4 (a weight of 4 being water)
                    if (hit.transform.GetComponent<HexWeight>().weight < 4)
                    {
                        //If the weight is less than 4 it will create an imaginary GameObject and store that object in the StartCell list and set the selected cell's colour tint to green.
                        GameObject _startCellObj = hit.transform.gameObject;

                        hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
                        cellList.startCell.Add(_startCellObj);
                        _isLClicked = true;
                    }
                }

                //If you want to remove the path and/or start cell and end cell it will check if you Left click, and have control pressed down.
                if (_isLClicked == true && Input.GetKey(KeyCode.LeftControl))
                {
                    //Once the if statement returns true it will set the start cell colour to white, and empty the start cell list.
                    cellList.startCell[0].GetComponent<Renderer>().material.color = Color.white;
                    cellList.startCell.RemoveAt(0);
                    cellList.endCell.RemoveAt(0);
                    if (path.path != null) //It checks if the path contains a path. If not, it will do nothing.
                    {
                        for (int i = 0; i < path.path.Count; i++) //Reading through the path list to set every path element's colour to white again.
                        {
                            AStarInherit cell = (AStarInherit)path.path[i];
                            cell.GetComponent<Renderer>().material.color = Color.white;
                        }
                        path.path.Clear();
                    }
                    _isLClicked = false;
                    _isRClicked = false;
                }
            }
        }
        //In here the exact same happens as in the Left click function, only this time with a right click.
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (!_isRClicked)
                {
                    if (hit.transform.GetComponent<HexWeight>().weight < 4)
                    {
                        GameObject _endCellObj = hit.transform.gameObject;

                        hit.collider.GetComponent<Renderer>().material.color = Color.red;
                        cellList.endCell.Add(_endCellObj);
                        _isRClicked = true;
                    }
                }

                if (_isRClicked && Input.GetKey(KeyCode.LeftControl))
                {
                    cellList.endCell[0].GetComponent<Renderer>().material.color = Color.white;
                    cellList.endCell.RemoveAt(0);
                    cellList.startCell.RemoveAt(0);
                    if (path.path != null)
                    {
                        for (int i = 0; i < path.path.Count; i++)
                        {
                            AStarInherit cell = (AStarInherit)path.path[i];
                            cell.GetComponent<Renderer>().material.color = Color.white;
                        }
                        path.path.Clear();
                    }
                    _isRClicked = false;
                    _isLClicked = false;
                }
            }
        }
    }
}
