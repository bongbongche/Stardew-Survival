using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }    // plyaer controller로부터 마우스 위치를 가져옴
    public Animator animator;

    private bool attackBlocked;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 캐릭터를 기준으로 마우스 포인터의 상대적 위치 알아내기
        // Plow 스프라이트가 왼쪽을 바라보고 있어서 음수로 만들었음. 스프라이트에 따라 조절 필요
        Vector2 direction = -(PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        // 플레이어가 바라보는 방향으로 스프라이트 변경
        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;

        // 애니메이션 속도 조절. 일정 속도 이상으로 빨라지지는 않는데 왜지
        animator.SetFloat("AttackSpeed", gameManager.attackSpeed);
    }

    // 공격
    public void Attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    // 공격 딜레이
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(gameManager.attackDelay);
        attackBlocked = false;
    }
}
