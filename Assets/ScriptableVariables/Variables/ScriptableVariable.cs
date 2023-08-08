using UnityEngine;
using UnityEngine.Events;

public class ScriptableVariable<T> : ScriptableObject
{
    [SerializeField] private T _value;
    public T Value
    {
        get { return _value; }
        set { _value = value; OnValueChange.Invoke(_value); }
    }

    [HideInInspector] public UnityEvent<T> OnValueChange;

    public void Trigger()
    { OnValueChange.Invoke(_value); }
}
