using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [SerializeField] protected JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl { get => junkCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;
        junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + " : Load JunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        junkCtrl.JunkDespawn.DespawnObject();
    }

    public override void Reborn()
    {
        hpObjMax = junkCtrl.JunkSO.hpMax;
        base.Reborn();
    }
}
