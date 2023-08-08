using UnityEngine;

[RequireComponent(typeof(StateController))]
public class StateComponent : MonoBehaviour
{
    [SerializeField] private ScriptableState[] activeStates;
    protected StateController controller;

    protected virtual void Awake()
    {
        if(!controller) 
            controller = GetComponent<StateController>();

        controller.OnStateChanged.AddListener(OnStateChanged);
    }

    private void OnStateChanged(ScriptableState state)
    {
        this.enabled = HasActiveState(state);
    }

    private bool HasActiveState(ScriptableState state)
    {
        for (int i = 0; i < activeStates.Length; i++)
        {
            if (activeStates[i] == state) return true;
        }

        return false;
    }
}