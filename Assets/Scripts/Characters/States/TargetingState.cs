using UnityEngine;

public class TargetingState : CharacterStateComponent
{
    [SerializeField] private Transform tankCanon;
    [SerializeField] private float rotThreshold;

    private int RotSpeed
    { get { return manager.stats.canonRotSpeed; } }
    public bool TargetAtAim
    { get { return Mathf.Abs(dotFactor) > rotThreshold; } }

    private float dotFactor = 0;

    void FixedUpdate()
    {
        if (Target == null) // if there is no target, return to idle state
        { 
            manager.ChangeState("IDLE"); 
            return; 
        }
        else if(!manager.targetAtRange)
        {
            manager.ChangeState("CHASING");
            return;
        }

        // Calculate aim
        Vector3 targetDir = (Target.position - transform.position).normalized;
        dotFactor = Vector3.Dot(tankCanon.forward, targetDir);

        // Correct rotation
        float yAngle = tankCanon.eulerAngles.y;
        if (dotFactor > 0) yAngle += RotSpeed * .1f;
        else yAngle -= RotSpeed * .1f;

        // Assign rotation or start shooting
        if (TargetAtAim)
        {
            tankCanon.rotation =
                Quaternion.Euler(tankCanon.eulerAngles.x, yAngle, tankCanon.eulerAngles.z);
        }
        else
        {
            manager.ChangeState("SHOOTING");
        }
    }
}
