using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : BaseMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;

    protected override void LoadComponents()
    {
        LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
        }
        HidePrefabs();

        Debug.Log(transform.name + " :LoadPrefabs");
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        } 
    }

    public virtual Transform Spawn(string prefabName, Vector3 posSpawn, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null) Debug.LogError("Prefab not found!!");

        Transform newPrefab = Instantiate(prefab, posSpawn, rotation);
        return newPrefab;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach( Transform prefab in prefabs) 
        {
            if(prefab.name == prefabName) return prefab;
        }
        return null;
    }
}
