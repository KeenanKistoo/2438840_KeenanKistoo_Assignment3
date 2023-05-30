using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetection : MonoBehaviour
{

    public PowerupCollection power;
    public CrateController crate;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //print("player");
            if (power.availOne)
            {
                power.idOne = crate.id;
                //print(power.idOne);
                power.availOne = false;
                this.gameObject.SetActive(false);
                
            }else if (!power.availOne && power.availTwo) {
                power.idTwo = crate.id;
                power.availTwo = false;
                this.gameObject.SetActive(false);
            }
        }
    }


}
