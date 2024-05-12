using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected Vector3 dir = Vector3.right;

    private void Update()
    {
        transform.parent.Translate(speed * Time.deltaTime * dir);
    }
}
