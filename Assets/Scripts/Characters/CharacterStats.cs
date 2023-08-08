using UnityEngine;

[CreateAssetMenu(menuName = "TankBattle/CharacterStats")]
public class CharacterStats : ScriptableObject
{
    public int health;
    public int movSpeed;
    public int baseRotSpeed; // y axis
    public int canonRotSpeed; // y axis
    public WeaponStats weapon;
}
