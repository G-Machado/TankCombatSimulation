public class FloatAnimListener : AnimListener<float>
{
    protected override void SetAnimatorField(float value)
    {
        base.SetAnimatorField(value);
        animator.SetFloat(variable.name, value);
    }
}