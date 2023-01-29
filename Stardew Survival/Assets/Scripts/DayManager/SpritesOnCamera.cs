using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesOnCamera : MonoBehaviour
{
    [Header("ī�޶� ���� ����� ��������Ʈ")]
    public SpriteRenderer sr;

    [Header("���� ����")]
    public Color day;
    public Color night;
    private bool nightToDay;
    private GameManager gameManager;

    private void Awake()
    {
        float spriteX = sr.sprite.bounds.size.x;
        float spriteY = sr.sprite.bounds.size.y;

        float screenY = Camera.main.orthographicSize * 2;
        float screenX = screenY / Screen.height * Screen.width;

        transform.localScale = new Vector2(Mathf.Ceil(screenX / spriteX), Mathf.Ceil(screenY / spriteY));
        nightToDay = false;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    void Start()
    {



    }

    void Update()
    {
        if (nightToDay)
            sr.color = night*(0.3f + 0.7f*gameManager.nightTimer / gameManager.nightTime);
    } //�� -> �� ��� ����. ��ο� 30% ���� / 70% ��ο� -> ����

    public void ColorToDay()
    {
        nightToDay = false;
        sr.color = day;
    }

    public void ColorToNight()
    {
        sr.color = night;
        nightToDay = true;

    }

}
