using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : BaseMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl { get => junkCtrl;}

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
}
