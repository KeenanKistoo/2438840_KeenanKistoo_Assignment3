using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoison : MonoBehaviour
{
    [Header("Enemy Componenets:")]
    public GameObject enemy;
    public GameObject radius;
    
    

    [Header("Variables:")]
    private float minRad;
    private float maxRad;
    public bool inc;
    
    
    private void Start()
    {
        
        minRad = 1f;
        maxRad = 3f;
        inc = true;
    }

    private void Update()
    {
        RadiusCheck();
      
    }


    
    public void RadiusCheck()
    {
        if (inc)
        {
            Transform radiusTrans = radius.transform;
            radius.transform.localScale = new Vector3(radiusTrans.localScale.x + 0.25f * Time.deltaTime, radiusTrans.localScale.y + 0.25f * Time.deltaTime, radiusTrans.localScale.z);
            Vector3 maxTransform = new Vector3 (maxRad, maxRad, 1f);
            if(radius.transform.localScale.x >= maxTransform.x)
            {
                print("reached max");
                inc = false;
            }
        }else if (!inc)
        {
            Transform radiusTrans = radius.transform;
            radius.transform.localScale = new Vector3(radiusTrans.localScale.x - 1 * Time.deltaTime, radiusTrans.localScale.y - 1 * Time.deltaTime, radiusTrans.localScale.z);
            Vector3 minTransform = new Vector3(minRad, minRad, 1f);
            if (radius.transform.localScale.x <=  minTransform.x)
            {
                print("reached min");
                inc = true;
            }
        }
    }

    
    
}
