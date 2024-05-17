using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rb;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSphereCollider();
        LoadRigibody();
    }

    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return; 
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + " : Load Collider", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if(rb != null) return;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        Debug.Log(transform.name + " : Load Rigibody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        BulletCtrl.DamageSender.Send(other.transform);
    }
}
