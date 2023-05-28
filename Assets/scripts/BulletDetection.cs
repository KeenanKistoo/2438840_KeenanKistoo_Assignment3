using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDetection : MonoBehaviour
{
    public GameObject explosion;
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy")) {
            print("enemy");
            
        }
        else if (coll.gameObject.CompareTag("Loot"))
        {
            print("loot");
        } else if (coll.gameObject.CompareTag("Wall"))
        {
            Vector3 currPos = transform.position;
            GameObject particle = Instantiate(explosion, currPos, Quaternion.identity);

            this.gameObject.SetActive(false);

            Destroy(particle, 0.35f);
            Destroy(gameObject, 0.5f);
            print("wall");
        }
    }
}
