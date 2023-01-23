using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Vector3 mousePosition;
    private float angle;
    private float angleCorrection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateToMouseDirection();
    }

    // 무기가 마우스를 바라보게 함.
    private void RotateToMouseDirection()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        angle = Mathf.Atan2(transform.position.y - mousePosition.y, transform.position.x - mousePosition.x) * Mathf.Rad2Deg;
        angleCorrection = (angle + 90f);

        transform.rotation = Quaternion.AngleAxis(angleCorrection, Vector3.forward);
    }
}
