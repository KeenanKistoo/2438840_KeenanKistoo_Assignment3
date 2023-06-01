using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPoison : MonoBehaviour
{
    [Header("Enemy Componenets:")]
    public GameObject enemy;
    public GameObject radius;

    [Header("Slider:")]
    public Slider healthBar;
    public int maxHealth;

    [Header("Variables:")]
    private float minRad;
    private float maxRad;
    public bool inc;

    
    public RuntimeAnimatorController animControl;

    public GameObject comms;
    public Transform spawnComms;
    
    
    private void Start()
    {
        GetComponent<Animator>().enabled = false;
        minRad = 1f;
        maxRad = 3f;
        inc = true;
        healthBar.maxValue = maxHealth;
        healthBar.value = healthBar.maxValue;
    }

    private void Update()
    {
        RadiusCheck();
      StartCoroutine(EnemyHealth());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            print("bullet");
            healthBar.value -= 1f;
            GameObject minusOne = Instantiate(comms, spawnComms.transform.position, Quaternion.identity);
            minusOne.transform.position = spawnComms.transform.position;

            //Destroy(minusOne, 0.6f);
        }
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
              //  print("reached max");
                inc = false;
            }
        }else if (!inc)
        {
            Transform radiusTrans = radius.transform;
            radius.transform.localScale = new Vector3(radiusTrans.localScale.x - 1 * Time.deltaTime, radiusTrans.localScale.y - 1 * Time.deltaTime, radiusTrans.localScale.z);
            Vector3 minTransform = new Vector3(minRad, minRad, 1f);
            if (radius.transform.localScale.x <=  minTransform.x)
            {
                //print("reached min");
                inc = true;
            }
        }
    }

    IEnumerator EnemyHealth()
    {
        if(healthBar.value <= 0)
        {

            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            Animator anim = GetComponent<Animator>();
            anim.enabled = true;
            anim.runtimeAnimatorController = animControl;

            

            yield return new WaitForSeconds(0.5f);
            this.gameObject.SetActive(false);
        }
    }
    
}
