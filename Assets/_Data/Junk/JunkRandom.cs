using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : BaseMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnCtrl;
    public JunkSpawnerCtrl JunkSpawnCtrl { get => junkSpawnCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (junkSpawnCtrl != null) return;
        junkSpawnCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + " :Load JunkCtrl");
    }

    protected override void Start()
    {
        JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform posSpawn = JunkSpawnCtrl.JunkSpawnPoints.GetRandomPoint();
        Vector3 pos = posSpawn.position;
        Quaternion rot = posSpawn.rotation;
        Transform obj = JunkSpawnCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);

        Invoke(nameof(JunkSpawning), 1f);
    }
}
