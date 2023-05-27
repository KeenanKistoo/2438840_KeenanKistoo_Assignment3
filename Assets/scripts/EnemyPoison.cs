using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoison : MonoBehaviour
{
    [Header("Enemy Componenets:")]
    public GameObject enemy;
    
    

    [Header("Variables:")]
    private float minRad;
    private float maxRad;
    public bool inc;
    
    
    private void Start()
    {
        
        minRad = 0.5f;
        maxRad = 1.5f;
        inc = true;
    }

    private void Update()
    {
        RadiusCheck();
      
       
        
    }

    public void RadiusCheck()
    {

      
        


    }

    
}
