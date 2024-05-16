using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : BaseMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadJunkDespawn();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
        Debug.Log(transform.name + " : Load Model");
    }

    protected virtual void LoadJunkDespawn()
    {
        if(junkDespawn != null) return;
        junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": Load JunkDespawn");
    }
}
