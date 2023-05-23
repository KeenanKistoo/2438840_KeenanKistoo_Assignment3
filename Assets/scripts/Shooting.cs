using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPos;
    public GameObject bulletPrefab;
    

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
        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, shootPos.rotation); //= new Quaternion(shootPos.rotation.x, shootPos.rotation.y, shootPos.rotation.z - 90f, shootPos.rotation.w));
         Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.AddForce(shootPos.up * bulletForce, ForceMode2D.Impulse);
    }
}
