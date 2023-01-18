using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseSelect : MonoBehaviour
{

    public GridLayout grid;

    private SpriteRenderer spriteRenderer;
    private Vector3Int cellPosition;    // Ÿ���� ��ġ
    private Vector3 mousePosition;
    private Vector3 offset = new Vector3(0.5f, 0.5f, 0);
    public bool onGarden;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        setCellPosition();

        // �÷��̾ �� ��ó�� ���� ���� ��ȣ�ۿ� ����
        if(Mathf.Abs(transform.localPosition.x) > 1.5f || Mathf.Abs(transform.localPosition.y) > 1.5f)
        {
            // Ŀ���� �÷��̾�� �����Ÿ� �������� ���� ������ ��Ȱ��ȭ
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
        else
        {
            if(onGarden == true)
            {
                // Ŀ���� �÷��̾�� �����Ÿ� ���̰� Ŀ���� �� ���� ���� �� Ȱ��ȭ 
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                // Ŀ���� �÷��̾�� �����Ÿ� �������� Ŀ���� �� �ۿ� ���� �� ��Ȱ��ȭ
                spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            }
        }
        
    }

    // select ������Ʈ�� �� �������� ����ٴϰ� ����
    private void setCellPosition()
    {
        // ���콺 �������� ���� ���������� ���� (= ���� �÷��� ȭ���� ���콺 ��ġ�� ����)
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ���콺 �������� �� ���������� ����
        cellPosition = grid.WorldToCell(mousePosition);
        // select ������Ʈ�� �� �������� ����ٴϵ���
        transform.position = cellPosition + offset;
    }

    // ����� �浹�ϸ� ��������Ʈ �� Ȱ��ȭ
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Garden")
        {
            onGarden = true;
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    // ����� �浹�� ������ ��������Ʈ �� ��Ȱ��ȭ
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Garden")
        {
            onGarden = false;
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}