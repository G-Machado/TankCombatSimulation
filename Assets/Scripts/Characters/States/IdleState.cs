using System.Collections;
using UnityEngine;

public class IdleState : CharacterStateComponent
{
    [SerializeField] private float checkInterval;

    private Coroutine checkRoutine;

    protected override void OnStateEnable()
    {
        base.OnStateEnable();

        checkRoutine = StartCoroutine(CheckingForCharacters(checkInterval));
    }
    protected override void OnStateDisable()
    {
        base.OnStateDisable();

        if (checkRoutine != null)
            StopCoroutine(checkRoutine);
    }

    private IEnumerator CheckingForCharacters(float interval)
    {
        yield return new WaitForSeconds(interval);

        CharacterManager newTarget = 
            BattleManager.Instance.GetRandomTarget(manager);

        if(newTarget != null)
        {
            manager.target = newTarget.transform;
            manager.ChangeState("CHASING");
        }
        else
        {
            checkRoutine =
                StartCoroutine(CheckingForCharacters(interval));
        }
    }
}
