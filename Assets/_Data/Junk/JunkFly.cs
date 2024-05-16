using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentFly
{
    [SerializeField] protected float minCamPos = -18f;
    [SerializeField] protected float maxCamPos = 18f;
    protected override void ResetValue()
    {
        base.ResetValue();
        moveSpeed = 0.5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        GetFlyDirection();
    }

    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position;
        Vector3 objPos = transform.parent.position;

        camPos.x += Random.Range(minCamPos, maxCamPos);

        Vector3 dir = camPos - objPos;
        dir.Normalize();

        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0,0,rotZ);

        Debug.DrawLine(objPos, objPos + dir * 7, Color.red, Mathf.Infinity);
    }
}
