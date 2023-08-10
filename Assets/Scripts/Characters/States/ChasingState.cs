using UnityEngine;

public class ChasingState : CharacterStateComponent
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform tankBase;
    [SerializeField] private float rotThreshold;

    private int MovSpeed
    { get { return manager.stats.movSpeed; } }
    private int RotSpeed
    { get { return manager.stats.baseRotSpeed; } }

    void FixedUpdate()
    {
        if (!Target) // if there is no target, return to idle state
        {
            rb.velocity = Vector3.zero;
            manager.ChangeState("IDLE");
            return;
        }

        if(!manager.targetAtRange)
        {
            // Rotate tank base
            Vector3 targetDir = (Target.position - transform.position).normalized;
            float dotFactor = Vector3.Dot(tankBase.forward, targetDir);
            float yAngle = tankBase.eulerAngles.y;
            if (dotFactor > 0) yAngle += RotSpeed * .1f;
            else yAngle -= RotSpeed * .1f;

            if (Mathf.Abs(dotFactor) > rotThreshold)
            {
                tankBase.rotation =
                    Quaternion.Euler(tankBase.eulerAngles.x, yAngle, tankBase.eulerAngles.z);
            }

            // Move with velocity
            Vector3 targetVelocity = targetDir * MovSpeed;
            rb.velocity = targetVelocity;
        }
        else
        {
            // Start aiming to shot
            rb.velocity = Vector3.zero;
            controller.ChangeState("TARGETING");
        }
    }
}
