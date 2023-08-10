using UnityEngine;

[CreateAssetMenu(menuName = "TankBattle/CharacterStats")]
public class CharacterStats : ScriptableObject
{
    public int health;
    public int movSpeed;
    public int baseRotSpeed; 
    public int canonRotSpeed;
    public ScriptableWeapon weapon;
    public ScriptableFX deathExplosionFX;
}
