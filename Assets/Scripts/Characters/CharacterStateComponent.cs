using UnityEngine;

public class CharacterStateComponent : StateComponent
{
    protected CharacterManager manager;
    protected Transform Target
    {
        get { return manager.target; }
    }

    protected override void Awake()
    {
        base.Awake();
        manager = (CharacterManager)controller;
    }
}
