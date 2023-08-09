using UnityEngine;

public class TargetingState : CharacterStateComponent
{
    [SerializeField] private Transform tankCanon;
    [SerializeField] private float rotThreshold;

    private int RotSpeed
    { get { return manager.stats.canonRotSpeed; } }

    public bool atAim = false;

    void FixedUpdate()
    {
        if (Target == null || !manager.targetAtRange)
        { 
            manager.ChangeState("IDLE"); 
            return; 
        }

        // Calculate aim rotation
        Vector3 targetDir = (Target.position - transform.position).normalized;
        float dotFactor = Vector3.Dot(tankCanon.forward, targetDir);

        // Correct rotation
        float yAngle = tankCanon.eulerAngles.y;
        if (dotFactor > 0) yAngle += RotSpeed * .1f;
        else yAngle -= RotSpeed * .1f;

        // Assign rotation or change state
        if (Mathf.Abs(dotFactor) > rotThreshold)
        {
            tankCanon.rotation =
                Quaternion.Euler(tankCanon.eulerAngles.x, yAngle, tankCanon.eulerAngles.z);
        }
        else
        {
            controller.ChangeState("SHOOTING");
        }
    }

    public bool TargetAtAim()
    {
        Vector3 targetDir = (Target.position - transform.position).normalized;
        float dotFactor = Vector3.Dot(tankCanon.forward, targetDir);

        if (Mathf.Abs(dotFactor) > rotThreshold)
        {
            return false;
        }

        return true;
    }
}
