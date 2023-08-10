using System.Collections;
using UnityEngine;

public class ShootingState : CharacterStateComponent
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private TargetingState aimState;

    private float AttackSpeed
    { get { return manager.stats.attackSpeed; } }

    private Coroutine shootingRoutine;

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
        manager.scriptableStats.weapon.Shoot(shootPoint.position, shootPoint.rotation);

        yield return new WaitForSeconds(AttackSpeed);
        if (Target)
        {
            if (manager.targetAtRange && aimState.TargetAtAim)
                shootingRoutine = StartCoroutine(Shooting());
            else
            {
                manager.ChangeState("TARGETING");
            }
        }
        else
            manager.ChangeState("IDLE");
    }
}
