using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : BaseMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }

    [SerializeField] protected Transform mainCamera;
    public Transform MainCamera { get => mainCamera; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        GameCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (mainCamera != null) return;
        mainCamera = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.name + " : Load Camera", gameObject);
    }
}
