using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public static CharacterSpawner Instance; // polish singleton pattern
    private void Awake()
    {
        Instance = this;
    }

    public List<CharacterManager> charactersAlive; // this could be an array

    public CharacterManager GetRandomTarget(CharacterManager attacker)
    {
        List<CharacterManager> copyAlive = new List<CharacterManager>(); // this should be an array

        for (int i = 0; i < charactersAlive.Count; i++)
        {
            if (charactersAlive[i].Equals(attacker)) continue;

            copyAlive.Add(charactersAlive[i]);
        }

        if (copyAlive.Count <= 0)
            return null;
        else
            return copyAlive[Random.Range(0, copyAlive.Count)];
    }
}
