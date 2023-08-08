using Unity.VisualScripting;
using UnityEngine;

public class ChasingState : StateComponent
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform tankBase;
    [SerializeField] private float rotThreshold;

    private CharacterManager manager;
    private Transform target;
    private int movSpeed;
    private int rotSpeed;
    private float range;

    void Start()
    {
        manager = (CharacterManager) controller;

        movSpeed = manager.stats.movSpeed;
        rotSpeed = manager.stats.baseRotSpeed;
        target = manager.target;
        range = manager.stats.range;
    }

    void FixedUpdate()
    {
        if(!manager.targetAtRange)
        {
            Vector3 targetDir = (target.position - transform.position).normalized;
            float dotFactor = Vector3.Dot(tankBase.forward, targetDir);
            float yAngle = tankBase.eulerAngles.y;
            if (dotFactor > 0) yAngle += rotSpeed * .1f;
            else yAngle -= rotSpeed * .1f;

            if (Mathf.Abs(dotFactor) > rotThreshold)
            {
                tankBase.rotation =
                    Quaternion.Euler(tankBase.eulerAngles.x, yAngle, tankBase.eulerAngles.z);
            }

            // Move with velocity
            Vector3 targetVelocity = targetDir * movSpeed;
            rb.velocity = targetVelocity;
        }
        else
        {
            // Change state
            rb.velocity = Vector3.zero;
            controller.ChangeState("TARGETING");
        }
    }
}
