using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseSelect : MonoBehaviour
{

    public GridLayout grid;
    public Tilemap farmTile;    // ���� Ÿ��
    public TileBase changeTile; // �ٲ� Ÿ��

    private Vector3Int cellPosition;    // Ÿ���� ��ġ
    private Vector3 mousePosition;
    private Vector3 offset = new Vector3(0.5f, 0.5f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 �������� ���� ���������� ���� (= ���� �÷��� ȭ���� ���콺 ��ġ�� ����)
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ���콺 �������� �� ���������� ����
        cellPosition = grid.WorldToCell(mousePosition);
        // select ������Ʈ�� �� �������� ����ٴϵ���
        transform.position = cellPosition + offset;

        Plant();
    }

    // �Ĺ� �ɱ�
    private void Plant()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���� Ÿ�� �������� �Ĺ� �ɱ� ����
            if (farmTile.GetTile(cellPosition) != null)
            {
                farmTile.SetTile(cellPosition, changeTile);
            }
        }
    }
}
