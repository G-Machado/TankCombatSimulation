using System.Collections;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private ScriptableBullet bulletStats;
    private bool activated = true; // control bool for disabling trigger collisions when object is at pool
    private Coroutine destroyRoutine;

    public void SetupData(ScriptableBullet bulletStats)
    {
        this.bulletStats = bulletStats;
    }
    public void ResetBullet()
    {
        rb.velocity = transform.forward * bulletStats.speed;

        activated = true;

        destroyRoutine = StartCoroutine(DestroyBullet(5)); // initialize auto-destruction routine
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activated) return;

        // Perform damage at character
        CharacterManager enemyManager = other.GetComponent<CharacterManager>();
        enemyManager.DealDamage(bulletStats.damage);

        // Prepare rigidbody to be released back to the pool
        rb.velocity = Vector3.zero;

        if(destroyRoutine != null)
            StopCoroutine(destroyRoutine);

        activated = false;

        bulletStats.DestroyBullet(this.gameObject);
    }

    private IEnumerator DestroyBullet(float time) // Releases bullet back to the pool
    {
        yield return new WaitForSeconds(time);

        activated = false;
        bulletStats.DestroyBullet(this.gameObject);
    }
}
