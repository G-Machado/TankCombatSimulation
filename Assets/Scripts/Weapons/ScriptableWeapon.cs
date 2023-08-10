using UnityEngine;

[CreateAssetMenu(menuName = "TankBattle/WeaponStats")]
public class ScriptableWeapon : ScriptableObject
{
    public float attackSpeed;
    public float range;
    public ScriptableBullet bullet;
    public ScriptableFX shotExplosionFX;

    public void Shoot(Vector3 position, Quaternion rotation)
    {
        bullet.Spawn(position, rotation);
        shotExplosionFX.Spawn(position);
    }
}
