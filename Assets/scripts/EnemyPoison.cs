using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoison : MonoBehaviour
{
    [Header("Enemy Componenets:")]
    public GameObject enemy;
    private CircleCollider2D enCollider;
    

    [Header("Variables:")]
    private float minRad;
    private float maxRad;
    public bool inc;
    public bool incObj;
    
    private void Start()
    {
        enCollider =  enemy.GetComponent<CircleCollider2D>();
        minRad = 0.5f;
        maxRad = 1.5f;
        inc = true;
    }

    private void Update()
    {
        //RadiusCheck();
       ScaleCheck();
       
        
    }

    public void RadiusCheck()
    {

        if (inc){
            enCollider.radius += 0.25f * Time.deltaTime;
            
            if(enCollider.radius >= maxRad) { 
              inc = false;
            }
            else
            {
                return;
            }
        }else if (!inc) {
            enCollider.radius -= 0.25f * Time.deltaTime;

            if(enCollider.radius <= minRad){
                inc = true;
            } else { 
                return;
            }
        }


    }

    public void ScaleCheck()
    {
        Vector3 radius = enemy.transform.localScale;

        if (incObj) {
            enemy.transform.localScale = new Vector3(radius.x + (1f * Time.deltaTime), radius.y + (1f * Time.deltaTime), radius.z);
        }
    }

    public void Scale()
    {
        Vector3 localScale = enemy.transform.localScale;

        float average = (localScale.x + localScale.y) / 2f;

        enCollider.radius = average;
    }
}
