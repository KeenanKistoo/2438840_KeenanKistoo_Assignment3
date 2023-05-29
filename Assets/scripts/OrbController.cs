using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    [Header("Variables:")]
    public int orbCount;
    public int maxOrb;
    public int minOrb;

    [Header("Orb Sprites:")]
    public GameObject[] orbActive;
    public GameObject[] orbInactive;

    private void Start()
    {
        OrbSetup();
    }

    private void Update()
    {
        
    }

    public void OrbChange()
    {

    }

    public void OrbSetup()
    {
        maxOrb = 5;
        orbCount = maxOrb;
        minOrb = 0;

        for(int i = 0; i < 6; i++)
        {
            
            orbActive[i].SetActive(true);
            orbInactive[i].SetActive(false);
            print("done");
        }
    }

}
