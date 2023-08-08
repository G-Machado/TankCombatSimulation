using UnityEngine;

[DefaultExecutionOrder(-1)]
public class CharacterManager : StateController
{
    [SerializeField] private CharacterStats scriptableStats;

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

    public bool targetAtRange;
    public Transform target;

    private void Awake()
    {
        LoadStats();
    }

    protected override void Start()
    {
        base.Start();
    }
    private void LoadStats()
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
        targetAtRange = (target.position - transform.position).sqrMagnitude < stats.range * stats.range;
    }
}
