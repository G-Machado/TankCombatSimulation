using System.Collections;
using UnityEngine;

public class ShootingState : StateComponent
{
    private CharacterManager manager;
    private float attackSpeed;
    private Transform target;

    private Coroutine shootingRoutine; // should be placed at OnStateExit

    void Start()
    {
        manager = (CharacterManager)controller;
        attackSpeed = manager.stats.attackSpeed;
        target = manager.target;
    }

    private void OnEnable()
    {
        shootingRoutine = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        Debug.Log("SHOTING BULLET");

        yield return new WaitForSeconds(attackSpeed);
        if (target)
        {
            if (manager.targetAtRange)
                shootingRoutine = StartCoroutine(Shooting());
            else
            {
                StopCoroutine(shootingRoutine);
                manager.ChangeState("TARGETING");
            }
        }

    }
}
