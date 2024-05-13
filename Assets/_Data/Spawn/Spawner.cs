using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : BaseMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void LoadComponents()
    {
        LoadHolder();
        LoadPrefabs();
    }

    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
        Debug.Log(transform.name + " : Load Holder");
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

        Debug.Log(transform.name + " : Load Prefabs");
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

        Transform newPrefab = GetPrefabFromPool(prefab);
        newPrefab.SetLocalPositionAndRotation(posSpawn, rotation);

        newPrefab.parent = holder;
        return newPrefab;
    }

    protected virtual Transform GetPrefabFromPool( Transform prefab )
    {
        foreach( Transform poolObj in poolObjs)
        {
            if(prefab.name == poolObj.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
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
