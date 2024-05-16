using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : BaseMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected JunkSpawnPoints junkSpawnPoints;
    public JunkSpawnPoints JunkSpawnPoints { get => junkSpawnPoints; }

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
        if(junkSpawnPoints != null) return;
        junkSpawnPoints = FindAnyObjectByType<JunkSpawnPoints>();
        Debug.Log(transform.name + " : Load Junk Spawn Points");
    }
}
