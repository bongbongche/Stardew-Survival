using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseSelect : MonoBehaviour
{
    // Å¸ÀÏ¸Ê ÁÂÇ¥ ¾ò±â ½Ãµµ Áß
    public GridLayout grid;
    public Tilemap farmTile;
    public TileBase changeTile;

    private Vector3Int cellPosition;
    private Vector3 mousePosition;
    private Vector3 offset = new Vector3(0.5f, 0.5f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cellPosition = grid.WorldToCell(mousePosition);
        transform.position = cellPosition + offset;

        if(Input.GetMouseButtonDown(0))
        {
            if(farmTile.GetTile(cellPosition).name == "Desert _6")
            {
                farmTile.SetTile(cellPosition, changeTile);
            }
        }
    }
}
