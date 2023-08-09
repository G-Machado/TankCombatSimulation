using UnityEngine;

public class CharacterStateComponent : StateComponent
{
    protected CharacterManager manager;
    protected Transform Target
    {
        get { return manager.target; }
        set { manager.target = value; }
    }

    protected override void Awake()
    {
        base.Awake();
        manager = (CharacterManager)controller;
    }
}
