using UnityEngine;
using UnityEngine.Events;

public class StateController : MonoBehaviour
{
    public ScriptableState[] possibleStates;
    public UnityEvent<ScriptableState> OnStateChanged;

    private int stateIndex = 0;
    protected ScriptableState currentState
    { get { return possibleStates[stateIndex]; } }

    protected virtual void Start()
    {
        OnStateChanged.Invoke(currentState);
    }

    public void ChangeState(string stateName)
    {
        for (int i = 0; i < possibleStates.Length; i++)
        {
            if (possibleStates[i].name.Equals(stateName))
            {
                stateIndex = i;
                OnStateChanged.Invoke(currentState);
                return;
            }
        }

        Debug.LogError("There is no possible state with that name.");
    }
}
