using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class AnimListener<T> : VariableListener<T>
{
    protected Animator animator;
    protected bool paramCheck = false;

    private Dictionary<System.Type, AnimatorControllerParameterType> paramsTypes
        = new Dictionary<System.Type, AnimatorControllerParameterType>
    {
        { typeof(int), AnimatorControllerParameterType.Int},
        { typeof(float), AnimatorControllerParameterType.Float},
        { typeof(bool), AnimatorControllerParameterType.Bool}
        //{ typeof(trigger), AnimatorControllerParameterType.Trigger},
    };

    protected override void Awake()
    {
        // Setup references
        animator = GetComponent<Animator>();
        CheckParameters();

        // Initialize listener
        base.Awake();
    }

    private void CheckParameters()
    {
#if UNITY_EDITOR
        AnimatorControllerParameter[] parameters = animator.parameters;
        System.Type classType = typeof(T);
        for (int i = 0; i < parameters.Length; i++)
        {
            AnimatorControllerParameterType parameterType = parameters[i].type;
            if (paramsTypes.ContainsKey(classType) && parameterType.Equals(paramsTypes[classType]))
                paramCheck = true;
        }

        if (!paramCheck)
            throw new System.Exception($"Parameter name and/or type mismatch. Check {this.gameObject.name} animator for discrepancies.");
#endif
    }

    protected override void OnVariableValueChange(T value)
    {
        base.OnVariableValueChange(value);
        SetAnimatorField(value);
    }

    protected virtual void SetAnimatorField(T value)
    {
        if (!paramCheck) return;
    }
}
