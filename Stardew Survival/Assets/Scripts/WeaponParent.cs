using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }    // plyaer controller로부터 마우스 위치를 가져옴
    public Animator animator;
    public Transform circleOrigin;

    private GameManager gameManager;
    private SpriteRenderer weaponSpriteRenderer;
    private GameObject player;
    private PlayerController playerController;

    public int weaponMode; // 0: 1단계 무기, 1: 2단계 무기, 2: 3단계 무기
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
        playerController = player.GetComponent<PlayerController>();
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

        weaponMode = player.GetComponent<PlayerController>().weaponModeOnPlayerControl;
        // 무기에 따라 스펙 변경
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

    // 공격
    public void Attack()
    {
        if (playerController.attackBlocked)
        {
            return;
        }
        animator.SetTrigger("Attack");
        playerController.attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    // 공격 딜레이
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(gameManager.attackDelay);
        playerController.attackBlocked = false;
    }

    // 무기 기즈모 설정
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, weaponRadius);
    }

    // 무기 공격 모션 충돌 감지
    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, weaponRadius))
        {
            // 적 피해 입히기 & 넉백
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
