using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponDamage = 10;

    float tempTime = 0;
    public float cd = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "enemy")
        {
            if(Time.time - tempTime > cd)//attack once per second
            {
                
                
                    other.gameObject.GetComponent<EnemyStatic>().TakeDamage(weaponDamage);
                    tempTime = Time.time;
                    Debug.Log("hit");
                
                
            }
        
        
        }
    }
}
