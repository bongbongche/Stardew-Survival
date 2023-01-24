using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHelper : MonoBehaviour
{
    public UnityEvent OnAnimationEventTriggered, OnAttackPerformed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEvent()
    {
        OnAnimationEventTriggered?.Invoke();
    }

    // weapon parent에 DetectCollider 함수가 실행되는지 감시
    public void TriggerAttack()
    {
        OnAttackPerformed?.Invoke();
    }
}
