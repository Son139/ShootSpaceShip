using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : BaseMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 dir = Vector3.right;

    private void Update()
    {
        transform.parent.Translate(moveSpeed * Time.deltaTime * dir);
    }
}
