using UnityEngine;

[CreateAssetMenu(menuName ="TankBattle/FX")]
public class ScriptableFX : ScriptablePool
{
    public void Spawn(Vector3 position)
    {
        GameObject fxClone = pool.Get();
        fxClone.transform.parent = BulletSpawner.Instance.transform;
        fxClone.transform.position = position;

        fxClone.GetComponent<FXManager>().SetupData(this);
    }

    public void DestroyFX(GameObject obj)
    {
        pool.Release(obj);
    }

    
}
