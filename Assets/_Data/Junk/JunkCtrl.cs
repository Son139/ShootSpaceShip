using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : BaseMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints { get => spawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkSpawner();
        LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (junkSpawner != null) return;
        junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + " : Load JunkSpawn");
    }

    protected virtual void LoadSpawnPoints()
    {
        if(spawnPoints != null) return;
        spawnPoints = Transform.FindAnyObjectByType<SpawnPoints>();
        Debug.Log(transform.name + " : Load Spawn Points");
    }
}
