using UnityEngine;

[CreateAssetMenu(menuName ="TankBattle/Bullet")]
public class ScriptableBullet : ScriptablePool
{
    public int damage;
    public int speed;
    public ScriptableFX particleFX;

    public void Spawn(Vector3 position, Quaternion rotation)
    {
        GameObject bulletClone = Pool.Get();
        bulletClone.transform.parent = BattleManager.Instance.transform;
        bulletClone.transform.position = position;
        bulletClone.transform.rotation = rotation;

        bulletClone.GetComponent<BulletManager>().ResetBullet();
    }

    protected override void SetupObject(GameObject obj)
    {
        BulletManager bManager = obj.GetComponent<BulletManager>();
        bManager.SetupData(this);
    }

    public void DestroyBullet(GameObject obj) // Releases bullet back to the pool
    {
        if(particleFX)
            particleFX.Spawn(obj.transform.position);

        Pool.Release(obj);
    }
}
