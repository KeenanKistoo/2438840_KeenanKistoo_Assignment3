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


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, shootPos.rotation); 
         Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.AddForce(shootPos.up * bulletForce, ForceMode2D.Impulse);

        int count = orbControl.orbCount;

        if(count > -1)
        {
            orbControl.orbActive[count].SetActive(false);
            orbControl.orbInactive[count].SetActive(true);
            orbControl.orbCount--;
        }
    }
}
