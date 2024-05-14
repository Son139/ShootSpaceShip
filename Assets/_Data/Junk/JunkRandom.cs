using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : BaseMonoBehaviour
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
        junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log(transform.name + " :Load JunkCtrl");
    }

    protected override void Start()
    {
        JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform posSpawn = JunkCtrl.SpawnPoints.GetRandomPoint();
        Vector3 pos = posSpawn.position;
        Quaternion rot = posSpawn.rotation;
        Transform obj = junkCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);

        Invoke(nameof(JunkSpawning), 1f);
    }
}
