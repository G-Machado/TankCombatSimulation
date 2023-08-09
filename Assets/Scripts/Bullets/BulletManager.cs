using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private ScriptableBullet bulletStats;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb.velocity = transform.forward * bulletStats.speed;
        Destroy(this.gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterManager enemyManager = other.GetComponent<CharacterManager>();
        enemyManager.DealDamage(bulletStats.damage);

        Debug.Log("Spawn explosion FX!");
        Destroy(this.gameObject);
    }
}
