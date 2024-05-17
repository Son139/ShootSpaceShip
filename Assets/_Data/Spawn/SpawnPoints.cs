using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : BaseMonoBehaviour
{
    [SerializeField] protected List<Transform> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (points.Count > 0) return;
        foreach (Transform point in transform)
        {
            points.Add(point);
            Debug.Log(point.name);
        }
        Debug.Log(transform.name + " :Load Point", gameObject);
    }

    public virtual Transform GetRandomPoint()
    {
        int rand = Random.Range(0, points.Count);
        return points[rand];
    }
}
