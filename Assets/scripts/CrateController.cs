using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    [SerializeField]
    private int hitCount;
    public GameObject[] boxes;

    private void Start()
    {
        BoxSetup();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            BoxHit();
        }
    }

    public void BoxSetup()
    {
        hitCount = 0;
        boxes[hitCount].SetActive(true);

        for(int i = 1; i < boxes.Length; i++)
        {
            boxes[i].SetActive(false);
        }
    }

    public void BoxHit()
    {
        hitCount++;
       
        if (hitCount >= boxes.Length)
        {
            print("complete");
        } else if (hitCount < boxes.Length)
        {
            boxes[hitCount].SetActive(true);
            boxes[hitCount - 1].SetActive(false);
        }
    }
}
