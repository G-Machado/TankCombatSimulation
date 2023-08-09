using UnityEngine;

[CreateAssetMenu(menuName ="TankBattle/Bullet")]
public class ScriptableBullet : ScriptablePool
{
    public int damage;
    public int speed;
    public ScriptableFX particleFX;

    public void Spawn(Vector3 position, Quaternion rotation)
    {
        GameObject bulletClone = pool.Get();
        bulletClone.transform.parent = BulletSpawner.Instance.transform;
        bulletClone.transform.position = position;
        bulletClone.transform.rotation = rotation;

        BulletManager bManager = bulletClone.GetComponent<BulletManager>();
        bManager.SetupData(this);
    }

    public void DestroyBullet(GameObject obj)
    {
        if(particleFX)
            particleFX.Spawn(obj.transform.position);

        pool.Release(obj);
    }
}
