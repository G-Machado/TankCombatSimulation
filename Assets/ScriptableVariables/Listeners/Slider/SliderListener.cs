using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class SliderListener<T> : MonoBehaviour
{
    [SerializeField] protected ScriptableVariable<T> variable_current;
    [SerializeField] protected ScriptableVariable<T> variable_total;
    [SerializeField] private bool listenAtAwake;
    public UnityEvent<T> OnVariableChange;

    public abstract float GetSliderRatio();

    protected virtual void Awake()
    {
        if (listenAtAwake)
            OnVariableValueChange(variable_current.Value);
    }

    private void OnEnable()
    {
        //
        if (variable_total != null)
            variable_total.OnValueChange.AddListener(OnVariableValueChange);
        else
            throw new System.NullReferenceException($"No ScriptableVariable current assigned to listener.");

        //
        if (variable_total != null)
            variable_total.OnValueChange.AddListener(OnVariableValueChange);
        else
            throw new System.NullReferenceException($"No ScriptableVariable total assigned to listener.");
    }
    private void OnDisable()
    {
        //
        if (variable_current != null)
            variable_current.OnValueChange.RemoveListener(OnVariableValueChange);
        else
            throw new System.NullReferenceException($"No ScriptableVariable current assigned to listener.");

        //
        if (variable_total != null)
            variable_total.OnValueChange.RemoveListener(OnVariableValueChange);
        else
            throw new System.NullReferenceException($"No ScriptableVariable total assigned to listener.");
    }
    protected virtual void OnVariableValueChange(T value)
    {
        OnVariableChange.Invoke(value);
    }
}
