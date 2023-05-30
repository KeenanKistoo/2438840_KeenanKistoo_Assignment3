using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthControl : MonoBehaviour
{
    public Slider healthBar;
    public int maxHealth;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        HealthSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthSetup()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }
}
