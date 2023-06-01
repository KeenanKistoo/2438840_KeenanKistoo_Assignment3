using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShoot : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] shootPos;
    public Slider[] healthBars;

    public GameObject bulletPrefab;

    public GameObject player;

    bool canCheck;
    public float timer;
    public float shootCount;
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
            timer += 1 * Time.deltaTime;

            if(timer >= shootCount) {
                canCheck = true;
            }
            
        }
    }

   public void Shoot()
    {
        int ranNum = Random.Range(0, enemies.Length);

        //enemies[ranNum].gameObject.SetActive(false);
        print(enemies[ranNum].name);
        GameObject bullet = Instantiate(bulletPrefab, shootPos[ranNum].transform.position,Quaternion.identity);
        bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        
        canCheck = false;
        timer = 0;
    }
}
