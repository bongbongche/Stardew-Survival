using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�㳷 ���� ��, �������� ������� ������Ʈ ���� ��ũ��Ʈ
public class DayManager : MonoBehaviour
{
    [Header("�㳷����")]
    public SpritesOnCamera spriteOnCamera; // ����Ƽ���� ����

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
    }//���� �� �� �۵���Ű�� �͵�

    public void TurnsToDay()
    {
        spriteOnCamera.ColorToDay();
    }//���� �� �� �۵���Ű�� �͵�

}
