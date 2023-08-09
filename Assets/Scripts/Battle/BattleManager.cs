using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance; // polish singleton pattern
    private void Awake()
    {
        Instance = this;
    }

    public UnityEvent OnBattleBegin;
    public UnityEvent OnBattleFinish;
    public UnityEvent<CharacterManager> OnCharacterDeath;

    public List<CharacterManager> charactersAlive; // this could be an array
    public bool battleStarted = false;

    public CharacterManager GetRandomTarget(CharacterManager attacker)
    {
        if (charactersAlive.Count <= 1) return null;

        CharacterManager[] copyAlive = new CharacterManager[charactersAlive.Count - 1];

        int index = 0;
        for (int i = 0; i < charactersAlive.Count; i++)
        {
            if (charactersAlive[i].Equals(attacker)) continue;

            copyAlive[index] = charactersAlive[i];
            index++;
        }

        return copyAlive[Random.Range(0, copyAlive.Length)];
    }

    public void StartBattle()
    {
        battleStarted = true;

        OnBattleBegin?.Invoke();
    }

    private void EndBattle()
    {
        battleStarted = false;

        OnBattleFinish?.Invoke();
    }

    public void KillCharacter(CharacterManager character)
    {
        charactersAlive.Remove(character);
        OnCharacterDeath?.Invoke(character);

        if (charactersAlive.Count <= 1)
            EndBattle();
    }
}
