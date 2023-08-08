using System;
using UnityEngine;
using UnityEngine.Events;

public class StateController : MonoBehaviour
{
    public ScriptableState[] possibleStates;
    public UnityEvent<ScriptableState> OnStateChanged;

    private int stateIndex = 0;
    protected ScriptableState currentState
    {
        get { return possibleStates[stateIndex]; }
    }

    protected virtual void Start()
    {
        OnStateChanged.Invoke(currentState);
    }
    public virtual void ChangeState(string stateName)
    {
        bool changed = false;
        for (int i = 0; i < possibleStates.Length; i++)
        {
            if (possibleStates[i].name.Equals(stateName))
            {
                stateIndex = i;
                OnStateChanged.Invoke(currentState);
                changed = true;
            }
        }

        if (!changed) 
            Debug.LogWarning("There is no possible state with that name");
    }
}
