using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    private ScriptableFX fxStats;

    public void SetupData(ScriptableFX fx)
    {
        fxStats = fx;
        StartCoroutine(DestroyFX(fx.duration));
    }

    private IEnumerator DestroyFX(float time)
    {
        yield return new WaitForSeconds(time);
        fxStats.DestroyFX(this.gameObject);
    }
}
