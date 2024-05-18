using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DamageReceiver : BaseMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hpObj;
    [SerializeField] protected int hpObjMax;
    [SerializeField] protected bool isDead = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.2f;
        Debug.Log(transform.name + " : Load Collider", gameObject);
    }
    protected override void OnEnable()
    {
        Reborn();
    }

    public virtual void Reborn()
    {
        hpObj = hpObjMax;
        isDead = false;
    }

    public virtual void AddHp(int hp)
    {
        if (isDead) return;

        hpObj += hp;
        if (hpObj > hpObjMax) hpObjMax = hpObj;
    }

    public virtual void DeductHp(int hp)
    {
        if (isDead) return;

        hpObj -= hp;
        if (hpObj < 0) hpObj = 0;
        CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return hpObj <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        isDead = true;
        OnDead();
    }

    protected virtual void OnDead() { }
}
