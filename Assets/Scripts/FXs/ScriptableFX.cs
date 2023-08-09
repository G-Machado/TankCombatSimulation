using UnityEngine;

[CreateAssetMenu(menuName ="TankBattle/FX")]
public class ScriptableFX : ScriptablePool
{
    public float duration;

    public void Spawn(Vector3 position)
    {
        GameObject fxClone = pool.Get();
        fxClone.transform.parent = BattleManager.Instance.transform;
        fxClone.transform.position = position;

        fxClone.GetComponent<FXManager>().SetupData(this);
    }

    public void DestroyFX(GameObject obj)
    {
        pool.Release(obj);
    }
}
