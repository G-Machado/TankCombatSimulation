using UnityEngine;

public class TargetingState : StateComponent
{
    [SerializeField] private Transform tankCanon;
    [SerializeField] private float rotThreshold;
    
    private Transform target;
    private CharacterManager manager;
    private int rotSpeed;

    void Start()
    {
        manager = (CharacterManager)controller;
        rotSpeed = manager.stats.canonRotSpeed;
        target = manager.target;
    }

    void FixedUpdate()
    {
        // Correct tank canon rotation
        Vector3 targetDir = (target.position - transform.position).normalized;
        float dotFactor = Vector3.Dot(tankCanon.forward, targetDir);
        float yAngle = tankCanon.eulerAngles.y;
        if (dotFactor > 0) yAngle += rotSpeed * .1f;
        else yAngle -= rotSpeed * .1f;

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
}
