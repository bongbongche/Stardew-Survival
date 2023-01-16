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

    private void Awake()
    {
        float spriteX = sr.sprite.bounds.size.x;
        float spriteY = sr.sprite.bounds.size.y;

        float screenY = Camera.main.orthographicSize * 2;
        float screenX = screenY / Screen.height * Screen.width;

        transform.localScale = new Vector2(Mathf.Ceil(screenX / spriteX), Mathf.Ceil(screenY / spriteY));
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ColorToDay()
    {
        sr.color = day;
    }

    public void ColorToNight()
    {
        sr.color = night;
    }

}
