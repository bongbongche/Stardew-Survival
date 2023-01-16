using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour
{
    // Å¸ÀÏ¸Ê ÁÂÇ¥ ¾ò±â ½Ãµµ Áß
    public Grid grid;
    public Vector3Int gridPosition;
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gridPosition = grid.WorldToCell(mousePosition);
        //Debug.Log(gridPosition);
        //mousePosition = new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));
        transform.position = gridPosition;
    }
}
