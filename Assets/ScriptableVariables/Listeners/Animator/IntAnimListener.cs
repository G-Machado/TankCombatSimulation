using UnityEngine;

public class IntAnimListener : AnimListener<int>
{
    protected override void SetAnimatorField(int value)
    {
        base.SetAnimatorField(value);
        animator.SetInteger(variable.name, value);
    }
}