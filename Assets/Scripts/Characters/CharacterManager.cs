using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class CharacterManager : StateController
{
    public CharacterStats scriptableStats;
    [SerializeField] private Slider healthBar;

    public struct statsData
    {
        public int health;
        public int movSpeed;
        public int baseRotSpeed;
        public int canonRotSpeed;
        public float attackSpeed;
        public float range;
    }
    public statsData stats;

    [HideInInspector] public bool targetAtRange;
    [HideInInspector] public Transform target;

    private void Awake()
    {
        SetupData();
        BattleManager.Instance.charactersAlive.Add(this);
    }

    public void SetupData()
    {
        stats.health = scriptableStats.health;
        stats.movSpeed = scriptableStats.movSpeed;
        stats.baseRotSpeed = scriptableStats.baseRotSpeed;
        stats.canonRotSpeed = scriptableStats.canonRotSpeed;
        stats.attackSpeed = scriptableStats.weapon.attackSpeed;
        stats.range = scriptableStats.weapon.range;
    }

    void FixedUpdate()
    {
        if(target)
            targetAtRange = (target.position - transform.position).sqrMagnitude < stats.range * stats.range;
    }

    public void DealDamage(int damage)
    {
        stats.health -= damage;

        healthBar.gameObject.SetActive(true);
        healthBar.value = (stats.health + .01f) / scriptableStats.health;

        if (stats.health <= 0)
        {
            BattleManager.Instance.KillCharacter(this);

            if(scriptableStats.deathExplosionFX)
                scriptableStats.deathExplosionFX.Spawn(transform.position);

            Destroy(this.gameObject);
        }
    }
}
