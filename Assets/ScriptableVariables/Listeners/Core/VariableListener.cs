using UnityEngine;
using UnityEngine.Events;

public abstract class VariableListener<T> : MonoBehaviour
{
    [SerializeField] protected ScriptableVariable<T> variable;
    [SerializeField] private bool listenAtAwake;
    public UnityEvent<T> OnVariableChange;


    protected virtual void Awake()
    {
        if (listenAtAwake)
            OnVariableValueChange(variable.Value);
    }

    private void OnEnable()
    {
        if (variable != null)
            variable.OnValueChange.AddListener(OnVariableValueChange);
        else
            throw new System.NullReferenceException($"No ScriptableVariable assigned to listener.");
    }
    private void OnDisable()
    {
        if (variable != null)
            variable.OnValueChange.RemoveListener(OnVariableValueChange);
        else
            throw new System.NullReferenceException($"No ScriptableVariable assigned to listener.");
    }
    protected virtual void OnVariableValueChange(T value)
    {
        OnVariableChange.Invoke(value);
    }
}
