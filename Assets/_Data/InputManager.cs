using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] protected Vector3 targetPos;
    public Vector3 TargetPos { get => targetPos; }

    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogWarning("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }
    private void FixedUpdate()
    {
        GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
