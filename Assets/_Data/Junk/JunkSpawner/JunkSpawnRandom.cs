using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnRandom : BaseMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnCtrl;
    public JunkSpawnerCtrl JunkSpawnCtrl { get => junkSpawnCtrl; }

    [SerializeField] protected float randomDelay = 2f;
    [SerializeField] protected float randomTimer = 0;
    [SerializeField] protected int randomLimit = 9;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (junkSpawnCtrl != null) return;
        junkSpawnCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + " :Load JunkCtrl", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (RandomLimit()) return;

        randomTimer += Time.fixedDeltaTime;
        if (randomDelay > randomLimit) return;
        randomTimer = 0;

        Transform posSpawn = JunkSpawnCtrl.JunkSpawnPoints.GetRandomPoint();
        Vector3 pos = posSpawn.position;
        Quaternion rot = posSpawn.rotation;

        Transform prefab = JunkSpawner.Instance.RandomPrefab();
        Transform obj = JunkSpawnCtrl.JunkSpawner.Spawn(prefab.name, pos, rot);

        obj.gameObject.SetActive(true);
    }

    protected virtual bool RandomLimit()
    {
        int junkCurCount = junkSpawnCtrl.JunkSpawner.SpawnedCount;
        return junkCurCount >= randomLimit;
    }
}
