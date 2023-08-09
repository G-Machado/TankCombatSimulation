using UnityEngine;

[CreateAssetMenu(menuName ="TankBattle/Bullet")]
public class ScriptableBullet : ScriptableObject
{
    public int damage;
    public int speed;
    public GameObject prefab;
    //public ScriptableFX particleFX;

    public void Spawn(Vector3 position, Quaternion rotation)
    {
        BulletSpawner.Instance.SpawnBullet(this, position, rotation);
    }
}
