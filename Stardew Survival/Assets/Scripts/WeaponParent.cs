using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }    // plyaer controller�κ��� ���콺 ��ġ�� ������
    public Animator animator;
    public Transform circleOrigin;
    //public Sprite[] weaponSprite;

    private bool attackBlocked;
    private GameManager gameManager;
    private SpriteRenderer weaponSpriteRenderer;
    private GameObject player;

    public int weaponMode; // 0: 1�ܰ� ����, 1: 2�ܰ� ����, 2: 3�ܰ� ����
    public float weaponRadius;
    public float weaponAttackSpeed;
    public float weaponDamage;
    public float weaponKnockback;

    // Start is called before the first frame update
    void Start()
    {
        weaponMode = 0;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        weaponSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.Find("Player");
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

        weaponMode = player.GetComponent<PlayerController>().weaponModeOnPlayerControl;
        // ���⿡ ���� ���� ����
        if(weaponMode == 0)
        {
            weaponRadius = gameManager.weapon1Radius;
            weaponAttackSpeed = gameManager.weapon1AttackSpeed;
            weaponDamage = gameManager.weapon1Damage;
            weaponKnockback = gameManager.weapon1Knockback;
        }
        else if (weaponMode == 1)
        {
            weaponRadius = gameManager.weapon2Radius;
            weaponAttackSpeed = gameManager.weapon2AttackSpeed;
            weaponDamage = gameManager.weapon2Damage;
            weaponKnockback = gameManager.weapon2Knockback;
            weaponSpriteRenderer.color = Color.red;
        }
        else if (weaponMode == 2)
        {
            weaponRadius = gameManager.weapon3Radius;
            weaponAttackSpeed = gameManager.weapon3AttackSpeed;
            weaponDamage = gameManager.weapon3Damage;
            weaponKnockback = gameManager.weapon3Knockback;
            weaponSpriteRenderer.color = Color.green;
        }
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

    // ���� ����� ����
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, weaponRadius);
    }

    // ���� ���� ��� �浹 ����
    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, weaponRadius))
        {
            // �� ���� ������ & �˹�
            if(collider.tag == "Enemy")
            {
                collider.gameObject.GetComponent<Enemy>().enemyPresentHp -= weaponDamage;
                if (player.transform.position.x > collider.transform.position.x)
                {

                    collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-weaponKnockback, 0f));
                }
                else
                {
                    collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(weaponKnockback, 0f));
                }

            }
        }
    }
}
