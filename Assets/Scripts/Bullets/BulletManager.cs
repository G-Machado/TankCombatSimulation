using System.Collections;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private ScriptableBullet bulletStats;
    private bool activated = true;
    private Coroutine destroyRoutine;

    public void SetupData(ScriptableBullet bulletStats)
    {
        this.bulletStats = bulletStats;
    }
    public void ResetBullet()
    {
        rb.velocity = transform.forward * bulletStats.speed;
        activated = true;

        destroyRoutine = StartCoroutine(DestroyBullet(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activated) return;

        CharacterManager enemyManager = other.GetComponent<CharacterManager>();
        enemyManager.DealDamage(bulletStats.damage);

        rb.velocity = Vector3.zero;

        if(destroyRoutine != null)
            StopCoroutine(destroyRoutine);

        activated = false;
        bulletStats.DestroyBullet(this.gameObject);
    }

    private IEnumerator DestroyBullet(float time)
    {
        yield return new WaitForSeconds(time);

        activated = false;
        bulletStats.DestroyBullet(this.gameObject);
    }
}
