using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    [SerializeField]
    private int hitCount;
    public GameObject[] boxes;
    public Sprite[] potions;
    public GameObject potionBottle;
    public int id;
    public bool canCollect;


    private void Start()
    {
        BoxSetup();
        RandomPowerup();
        print(id);
        potionBottle.SetActive(false);
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
            boxes[hitCount - 1].SetActive(false);
            canCollect = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //print(canCollect);
        } else if (hitCount < boxes.Length)
        {
            boxes[hitCount].SetActive(true);
            boxes[hitCount - 1].SetActive(false);
            canCollect = false;
        }

        if(hitCount == boxes.Length)
        {
            potionBottle.SetActive(true);
        }
    }

    public void RandomPowerup()
    {
        int ranNum = Random.Range(0,8);
        SpriteRenderer rend = potionBottle.GetComponent<SpriteRenderer>();

        if (ranNum == 1 || ranNum == 3 || ranNum == 4 || ranNum == 7)
        {
            id = 0;
            rend.sprite = potions[0];
            //print("heal");
        }else if(ranNum == 2)
        {
            id = 1;
            rend.sprite = potions[1];
            //print("Dmg overload");
        }else if(ranNum == 5 || ranNum == 6 || ranNum == 8 || ranNum == 0)
        {
            id = 2;
            rend.sprite = potions[2];
            //print("poison");
        }
        else
        {
            id = 0;
            rend.sprite = potions[0];
            //print("heal");
        }
        //print(ranNum);
    }

    
}
