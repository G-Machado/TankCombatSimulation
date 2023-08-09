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
    public ScriptableBullet bullet;

    public Transform target;
    //{ 
    //    get 
    //    {
    //        if (_target == null)
    //            CharacterSpawner.Instance.GetRandomTarget(this).transform;
    //        return _target;
    //    } 
    //}
    //public Transform _target;

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

        bullet = scriptableStats.weapon.bullet;
    }

    void FixedUpdate()
    {
        if(target)
            targetAtRange = (target.position - transform.position).sqrMagnitude < stats.range * stats.range;
    }

    public void DealDamage(int damage)
    {
        stats.health -= damage;
        
        if (stats.health <= 0)
        {
            Debug.Log("DEAD TANK");
            CharacterSpawner.Instance.charactersAlive.Remove(this);
            Destroy(this.gameObject);
        }
    }
}
