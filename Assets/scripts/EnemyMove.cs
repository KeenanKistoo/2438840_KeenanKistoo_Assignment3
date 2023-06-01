using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMove : MonoBehaviour
{
    [Header("Variables:")]
    public float speed;
    public float stopDistance;
    public bool control;

    public Slider healthBar;
    public RuntimeAnimatorController animControl;
    public int maxHealth;

    public EnemyShoot controller;


    public GameObject target;

    public GameObject comms;
    public Transform commsSpawn;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceTracker();
        StartCoroutine(EnemyHealth());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            healthBar.value -= 1;
           GameObject minusOne = Instantiate(comms, commsSpawn.transform.position, Quaternion.identity);

            Destroy(minusOne, 0.6f);
        }   
    }

    public void DistanceTracker()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.transform.position) <= stopDistance)
        {
            print("Reached");
        }
    }

    IEnumerator EnemyHealth()
    {
        if (healthBar.value <= 0 && !control)
        {

            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            Animator anim = GetComponent<Animator>();
            anim.enabled = true;
            anim.runtimeAnimatorController = animControl;



            yield return new WaitForSeconds(0.5f);
            this.gameObject.SetActive(false);
        }else if(healthBar.value <= 0 && control)
        {
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            Animator anim = GetComponent<Animator>();
            anim.enabled = true;
            anim.runtimeAnimatorController = animControl;

            for(int i = 0;i < controller.enemies.Length;i++)
            {
                controller.healthBars[i].value = 0;
            }

            yield return new WaitForSeconds(0.5f);
            this.gameObject.SetActive(false);
        }
    }




}
