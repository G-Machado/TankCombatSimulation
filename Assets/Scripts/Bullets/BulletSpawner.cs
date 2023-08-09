using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public static BulletSpawner Instance; // polish singleton pattern
    private void Awake()
    {
        Instance = this;
    }


    public void SpawnBullet(ScriptableBullet bullet, Vector3 position, Quaternion rotation)
    {
        GameObject bulletClone = Instantiate(bullet.prefab, position, rotation);
    }
}
