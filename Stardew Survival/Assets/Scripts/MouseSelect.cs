using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseSelect : MonoBehaviour
{

    public GridLayout grid;

    private SpriteRenderer spriteRenderer;
    private Vector3Int cellPosition;    // 타일의 위치
    private Vector3 mousePosition;
    private Vector3 offset = new Vector3(0.5f, 0.5f, 0);
    public bool onGarden;
    public bool isActivated;
    // Start is called before the first frame update
    void Start()
    {
        // 나중에 스프라이트 변경 필요
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        setCellPosition();

        // 플레이어가 밭 근처에 있을 때만 상호작용 가능
        if(Mathf.Abs(transform.localPosition.x) > 1.5f || Mathf.Abs(transform.localPosition.y) > 1.5f)
        {
            // 커서가 플레이어와 일정거리 떨어졌을 때는 무조건 비활성화
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            isActivated = false;
        }
        else
        {
            if(onGarden == true)
            {
                // 커서가 플레이어와 일정거리 안이고 커서도 밭 위에 있을 때 활성화 
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                isActivated = true;
            }
            else
            {
                // 커서가 플레이어와 일정거리 안이지만 커서가 밭 밖에 있을 때 비활성화
                spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
                isActivated = false;
            }
        }
        
    }

    // select 오브젝트가 셀 포지션을 따라다니게 설정
    private void setCellPosition()
    {
        // 마우스 포지션을 월드 포지션으로 변경 (= 게임 플레이 화면의 마우스 위치로 변경)
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 마우스 포지션을 셀 포지션으로 변경
        cellPosition = grid.WorldToCell(mousePosition);
        // select 오브젝트가 셀 포지션을 따라다니도록
        transform.position = cellPosition + offset;
    }

    // 가든과 충돌하면 스프라이트 색 활성화
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Garden" || collision.gameObject.tag == "EmptyGarden")
        {
            onGarden = true;
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    // 가든과 충돌이 끝나면 스프라이트 색 비활성화
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Garden" || collision.gameObject.tag == "EmptyGarden")
        {
            onGarden = false;
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}