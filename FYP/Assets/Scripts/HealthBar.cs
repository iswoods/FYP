using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    Image healthBar;
    float healthRate;

    public EnemyStatic es;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

        healthBar.fillAmount = es.GetHealthRate();
        
        if(es.GetHealthRate() > 0.3 && es.GetHealthRate() < 0.6)
        {
            healthBar.color = Color.yellow;
        }
        if (es.GetHealthRate() <= 0.3)
        {
            healthBar.color = Color.red;
        }
    }
}
