using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//밤낮 변경 시, 보여지고 사라지는 오브젝트 관리 스크립트
public class DayManager : MonoBehaviour
{
    [Header("밤낮음영")]
    public SpritesOnCamera spriteOnCamera; // 유니티에서 연결

    void Start()
    {
        TurnsToNight();
    }

    void Update()
    {
        
    }

    public void TurnsToNight()
    {
        spriteOnCamera.ColorToNight();
    }//밤이 될 때 작동시키는 것들

    public void TurnsToDay()
    {
        spriteOnCamera.ColorToDay();
    }//낮이 될 때 작동시키는 것들

}
