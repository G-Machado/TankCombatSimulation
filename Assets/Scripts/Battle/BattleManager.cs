using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BattleManager : Singleton<BattleManager>
{
    public UnityEvent OnBattleBegin;
    public UnityEvent OnBattleFinish;
    public UnityEvent<CharacterManager> OnCharacterDeath;

    [HideInInspector] public List<CharacterManager> charactersAlive;
    [SerializeField] private Text winnerUI;

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
        OnBattleBegin?.Invoke();
    }
    private void EndBattle()
    {
        OnBattleFinish?.Invoke();

        if (winnerUI)
        {
            winnerUI.text =
                $"{charactersAlive[0].gameObject.name} WINS";
            winnerUI.gameObject.SetActive(true);
        }
    }

    public void KillCharacter(CharacterManager character)
    {
        if (charactersAlive.Count <= 1) return;

        charactersAlive.Remove(character);
        OnCharacterDeath?.Invoke(character);

        if (charactersAlive.Count <= 1)
            EndBattle();
    }
}
