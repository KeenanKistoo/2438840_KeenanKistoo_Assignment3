using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Variables:")]
    public float speed;
    public float stopDistance;
    public bool control;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.transform.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }else if(Vector2.Distance(transform.position, target.transform.position) <= stopDistance)
        {
            print("Reached");
        }
    }


}
