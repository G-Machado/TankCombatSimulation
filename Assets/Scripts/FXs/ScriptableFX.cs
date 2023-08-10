using UnityEngine;

[CreateAssetMenu(menuName ="TankBattle/FX")]
public class ScriptableFX : ScriptablePool
{
    public float duration;

    public void Spawn(Vector3 position)
    {
        GameObject fxClone = Pool.Get();
        fxClone.transform.parent = BattleManager.Instance.transform;
        fxClone.transform.position = position;
    }

    protected override void SetupObject(GameObject obj)
    {
        FXManager fxManager = obj.GetComponent<FXManager>();
        fxManager.SetupData(this);
    }
    protected override void ResetObject(GameObject obj)
    {
        FXManager fxManager = obj.GetComponent<FXManager>();
        fxManager.ResetFX();
    }

    public void DestroyFX(GameObject obj)
    {
        Pool.Release(obj);
    }
}
