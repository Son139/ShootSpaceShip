using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 0.1f;

    private void FixedUpdate()
    {
        GetTargetPos();
        LookAtTarget();
        Moving();
    }

    protected virtual void GetTargetPos()
    {
        targetPos = InputManager.Instance.MouseWorldPos;
        targetPos.z = 0;
    }

    protected virtual void LookAtTarget()
    {
        Vector3 dir = targetPos - transform.parent.position;
        dir.Normalize();
        float rot_Z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_Z);
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, speed);
        transform.parent.position = newPos;
    }
}
