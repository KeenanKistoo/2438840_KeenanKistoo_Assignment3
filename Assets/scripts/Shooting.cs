using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPos;
    public GameObject bulletPrefab;

    public OrbController orbControl;

    public float bulletForce = 20f;

    public int reloadCount;

    public bool canShoot;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (canShoot) {
                AmmoCheck();
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            canShoot = false;
            StartCoroutine(Reload());
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, shootPos.rotation); 
         Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.AddForce(shootPos.up * bulletForce, ForceMode2D.Impulse);
        
    }

    public void AmmoCheck()
    {
        int count = orbControl.orbCount;
        if (count > -1)
        {
            orbControl.orbActive[count].SetActive(false);
            orbControl.orbInactive[count].SetActive(true);
            orbControl.orbCount--;
            Shoot();
        }
        else if (orbControl.orbCount <= -1)
        {
            print("empty");
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        canShoot = false;
        for (int i = 0;i < 6;i++)
        {
            orbControl.orbActive[i].SetActive(false);
            orbControl.orbInactive[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.1f);
        reloadCount = 0;
        orbControl.orbActive[reloadCount].SetActive(true);
        orbControl.orbInactive[reloadCount].SetActive(false);
        reloadCount++;
        yield return new WaitForSeconds(0.25f);

        orbControl.orbActive[reloadCount].SetActive(true);
        orbControl.orbInactive[reloadCount].SetActive(false);
        reloadCount++;
        yield return new WaitForSeconds(0.25f);

        orbControl.orbActive[reloadCount].SetActive(true);
        orbControl.orbInactive[reloadCount].SetActive(false);
        reloadCount++;
        yield return new WaitForSeconds(0.25f);

        orbControl.orbActive[reloadCount].SetActive(true);
        orbControl.orbInactive[reloadCount].SetActive(false);
        reloadCount++;
        yield return new WaitForSeconds(0.25f);

        orbControl.orbActive[reloadCount].SetActive(true);
        orbControl.orbInactive[reloadCount].SetActive(false);
        reloadCount++;
        yield return new WaitForSeconds(0.25f);

        orbControl.orbActive[reloadCount].SetActive(true);
        orbControl.orbInactive[reloadCount].SetActive(false);
        reloadCount++;
        orbControl.orbCount = orbControl.maxOrb;
        reloadCount = 0;
        canShoot = true;
    }
}


