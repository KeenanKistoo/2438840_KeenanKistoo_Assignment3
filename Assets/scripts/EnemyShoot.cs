using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] shootPos;

    public GameObject bulletPrefab;

    public GameObject player;

    bool canCheck;
    // Start is called before the first frame update
    void Start()
    {
        canCheck = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canCheck)
        {
            Shoot();
        }
        else
        {
            print("cannot check");
        }
    }

   public void Shoot()
    {
        int ranNum = Random.Range(0, enemies.Length);

        //enemies[ranNum].gameObject.SetActive(false);
        print(enemies[ranNum].name);
        GameObject bullet = Instantiate(bulletPrefab, shootPos[ranNum].transform.position,Quaternion.identity);
        
        canCheck = false;
    }
}
