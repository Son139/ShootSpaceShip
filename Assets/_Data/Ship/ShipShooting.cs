using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting;
    [SerializeField] protected float shootDelay;
    [SerializeField] protected float shootTimer;

    private void Update()
    {
        IsShooting();
    }

    private void FixedUpdate()
    {
        Shooting();
    }

    protected virtual void Shooting()
    {
        if (!isShooting) return;

        shootTimer += Time.fixedDeltaTime;
        if (shootDelay > shootTimer) return;
        shootTimer = 0f;

        Vector3 posSpawn = transform.position;
        Quaternion rotation = transform.parent.rotation;

        Transform newBullet = BulletSpawner.Instance.Spawn( BulletSpawner.bulletOne, posSpawn, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.name = BulletSpawner.bulletOne;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual bool IsShooting()
    {
        isShooting = InputManager.Instance.OnFiring == 1;
        return isShooting;
    }
}
