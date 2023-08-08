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
    }
    public statsData stats;

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
    }

    void Update()
    {
        
    }
}
