using UnityEngine;
using UnityEngine.Pool;

public class ScriptablePool : ScriptableObject
{
    [SerializeField] private GameObject prefab;

    private ObjectPool<GameObject> _pool;
    protected ObjectPool<GameObject> Pool
    {
        get 
        {
            if(_pool == null)
            {
                _pool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject, DestroyObject, true, 10, 100);
            }
            return _pool; 
        }
    }

    private GameObject CreateObject()
    {
        GameObject objectClone = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        SetupObject(objectClone);
        return objectClone;
    }
    private void GetObject(GameObject obj)
    {
        obj.SetActive(true);
        ResetObject(obj);
    }
    private void ReleaseObject(GameObject obj)
    { 
        obj.SetActive(false); 
    }
    private void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    // Helper functions to configure objects
    protected virtual void SetupObject(GameObject obj) { } // called at object creation
    protected virtual void ResetObject(GameObject obj) { } // called at object `Get()` from pool
}
