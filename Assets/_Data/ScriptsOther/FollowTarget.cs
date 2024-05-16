using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : BaseMonoBehaviour
{
    [SerializeField] protected Transform target;

    [SerializeField] protected float speed = 2f;

    protected virtual void FixedUpdate()
    {
        Following();
    }

    protected virtual void Following()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.fixedDeltaTime);
    }

}
