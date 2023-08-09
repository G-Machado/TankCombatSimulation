using UnityEngine;
using UnityEngine.Pool;

public class ScriptablePool : ScriptableObject
{
    [SerializeField] private GameObject prefab;

    private ObjectPool<GameObject> _pool;
    protected ObjectPool<GameObject> pool
    {
        get 
        {
            if(_pool == null)
            {
                _pool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject, DestroyObject);
            }
            return _pool; 
        }
    }

    private GameObject CreateObject()
    {
        return Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }
    private void GetObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    private void ReleaseObject(GameObject obj)
    { 
        obj.SetActive(false); 
    }
    private void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
