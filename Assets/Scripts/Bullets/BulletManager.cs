using System.Collections;
using System.Collections.Generic;
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


    private void Start()
    {
        rb.velocity = transform.forward * stats.speed;
        Destroy(this.gameObject, 10);
    }
    public void SetupData(ScriptableBullet bulletStats)
    {
        stats.damage = bulletStats.damage;
        stats.speed = bulletStats.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterManager enemyManager = other.GetComponent<CharacterManager>();
        enemyManager.DealDamage(stats.damage);

        Debug.Log("Spawn explosion FX!");
        Destroy(this.gameObject);
    }
}
