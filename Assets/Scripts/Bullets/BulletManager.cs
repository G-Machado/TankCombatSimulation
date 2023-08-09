using System.Collections;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private struct bulletData
    {
        public int damage;
        public int speed;
    }
    private bulletData stats;
    private ScriptableBullet _bulletStats;

    private bool activated = true;
    private Coroutine destroyRoutine;

    public void SetupData(ScriptableBullet bulletStats)
    {
        if (!_bulletStats)
        {
            stats.damage = bulletStats.damage;
            stats.speed = bulletStats.speed;
            _bulletStats = bulletStats;
        }

        rb.velocity = transform.forward * stats.speed;
        activated = true;

        destroyRoutine = StartCoroutine(DestroyBullet(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activated) return;

        CharacterManager enemyManager = other.GetComponent<CharacterManager>();
        enemyManager.DealDamage(stats.damage);

        Debug.Log("Spawn explosion FX!");

        rb.velocity = Vector3.zero;

        if(destroyRoutine != null)
            StopCoroutine(destroyRoutine);

        activated = false;
        _bulletStats.DestroyBullet(this.gameObject);
    }

    private IEnumerator DestroyBullet(float time)
    {
        yield return new WaitForSeconds(time);

        activated = false;
        _bulletStats.DestroyBullet(this.gameObject);
    }
}
