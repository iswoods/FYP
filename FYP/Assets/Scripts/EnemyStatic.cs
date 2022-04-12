using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStatic : MonoBehaviour
{
    public int enemyHealth = 100;
    public int currentHealth;
    public int enemyDamage = 10;

    EnemyAI eAI;

    // Start is called before the first frame update
    void Start()
    {
        eAI = GetComponent<EnemyAI>();
        currentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            eAI.PlayDeath();
            Destroy(gameObject, 3f);
            
        }
    }
    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
    }

    public float GetHealthRate()
    {

        return (float)currentHealth / (float)enemyHealth;
    }
}
