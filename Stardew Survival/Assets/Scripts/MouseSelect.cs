using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseSelect : MonoBehaviour
{

    public GridLayout grid;
    public Tilemap farmTile;    // 농장 타일
    public TileBase changeTile; // 바꿀 타일

    private Vector3Int cellPosition;    // 타일의 위치
    private Vector3 mousePosition;
    private Vector3 offset = new Vector3(0.5f, 0.5f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 포지션을 월드 포지션으로 변경 (= 게임 플레이 화면의 마우스 위치로 변경)
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 마우스 포지션을 셀 포지션으로 변경
        cellPosition = grid.WorldToCell(mousePosition);
        // select 오브젝트가 셀 포지션을 따라다니도록
        transform.position = cellPosition + offset;

        Plant();
    }

    // 식물 심기

    private void Plant()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 농장 타일 위에서만 식물 심기 가능
            if (farmTile.GetTile(cellPosition) != null)
            {
                farmTile.SetTile(cellPosition, changeTile);
            }
        }
    }
}
