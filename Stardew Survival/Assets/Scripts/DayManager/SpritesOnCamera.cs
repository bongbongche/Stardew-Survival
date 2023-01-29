using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesOnCamera : MonoBehaviour
{
    [Header("카메라 위에 씌우는 스프라이트")]
    public SpriteRenderer sr;

    [Header("음영 결정")]
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
    } //밤 -> 낮 밝기 변경. 어두움 30% 고정 / 70% 어두움 -> 밝음

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
