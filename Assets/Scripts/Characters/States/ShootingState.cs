using System.Collections;
using UnityEngine;

public class ShootingState : StateComponent
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private TargetingState targetState;

    private CharacterManager manager;
    private float attackSpeed;
    private Transform target
    { get { return manager.target; } }

    private Coroutine shootingRoutine;

    protected override void Awake()
    {
        base.Awake();

        manager = (CharacterManager)controller;
        attackSpeed = manager.stats.attackSpeed;
    }

    protected override void OnStateEnable()
    {
        shootingRoutine = StartCoroutine(Shooting());
    }

    protected override void OnStateDisable()
    {
        if(shootingRoutine != null)
            StopCoroutine(shootingRoutine);
    }

    private IEnumerator Shooting()
    {
        manager.bullet.Spawn(shootPoint.position, shootPoint.rotation);

        yield return new WaitForSeconds(attackSpeed);
        if (target)
        {
            if (manager.targetAtRange && targetState.TargetAtAim())
                shootingRoutine = StartCoroutine(Shooting());
            else
            {
                manager.ChangeState("TARGETING");
            }
        }
        else
            manager.ChangeState("CHASING");
    }
}
