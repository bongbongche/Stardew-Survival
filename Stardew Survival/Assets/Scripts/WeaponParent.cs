using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }    // plyaer controller�κ��� ���콺 ��ġ�� ������
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
        // ĳ���͸� �������� ���콺 �������� ����� ��ġ �˾Ƴ���
        // Plow ��������Ʈ�� ������ �ٶ󺸰� �־ ������ �������. ��������Ʈ�� ���� ���� �ʿ�
        Vector2 direction = -(PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        // �÷��̾ �ٶ󺸴� �������� ��������Ʈ ����
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

        // �ִϸ��̼� �ӵ� ����. ���� �ӵ� �̻����� ���������� �ʴµ� ����
        animator.SetFloat("AttackSpeed", gameManager.attackSpeed);
    }

    // ����
    public void Attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    // ���� ������
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(gameManager.attackDelay);
        attackBlocked = false;
    }
}
