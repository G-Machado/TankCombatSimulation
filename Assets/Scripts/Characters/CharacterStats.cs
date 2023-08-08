using UnityEngine;

[CreateAssetMenu(menuName = "TankBattle/CharacterStats")]
public class CharacterStats : ScriptableObject
{
    public int health;
    public int movSpeed;
    public int rotSpeed; // y axis

    //[SerializeField] private WeaponStats weapon;
}
