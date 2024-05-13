using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float distanceLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCamera;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (mainCamera != null) return;
        mainCamera = Transform.FindObjectOfType<Camera>().transform;
    }

    protected override bool CanDespawn()
    {
        distance = Vector3.Distance(mainCamera.position, transform.position);
        if (distance > distanceLimit) return true;
        return false;
    }
}
