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
            if (manager.targetAtRange && aimState.TargetAtAim) // if target is still at aim, shoots
                shootingRoutine = StartCoroutine(Shooting());
            else                                               // else, get back to aiming
                manager.ChangeState("TARGETING");
        }
        else // if there is no target, return to idle state
            manager.ChangeState("IDLE");
    }
}
