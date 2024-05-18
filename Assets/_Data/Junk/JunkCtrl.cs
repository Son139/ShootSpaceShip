using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : BaseMonoBehaviour
{
    [Header("JunkCtrl")]
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] protected JunkSO junkSO;
    public JunkSO JunkSO { get => junkSO; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadJunkDespawn();
        LoadJunkSO();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
        Debug.Log(transform.name + " : Load Model", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (junkDespawn != null) return;
        junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": Load JunkDespawn", gameObject);
    }

    protected virtual void LoadJunkSO()
    {
        if (junkSO != null) return;
        string resPath = "Junk/" + transform.name;
        junkSO = Resources.Load<JunkSO>(resPath);
        Debug.LogWarning(transform.name + " : Load JunkSO", gameObject);
    }
}
