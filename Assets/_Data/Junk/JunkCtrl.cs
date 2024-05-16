using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : BaseMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
        Debug.Log(transform.name + " : Load Model");
    }
}
