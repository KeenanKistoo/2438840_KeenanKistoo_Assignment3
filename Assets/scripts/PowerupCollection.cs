using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupCollection : MonoBehaviour
{
    public bool availOne;
    public bool availTwo;

    public int idOne;
    public int idTwo;

    public Sprite[] potions;

    public Image potionOne;
    public Image potionTwo;

    private void Start()
    {
        idOne = 4;
        idTwo = 5;
    }
    private void Update()
    {
        if (idOne == 0 || idOne == 1 ||idOne == 2)
        {
            potionOne.sprite = potions[idOne];
            potionOne.color = Color.white;
        }else if(idTwo == 0 || idTwo == 1 || idTwo == 2)
        {
            potionTwo.sprite = potions[idTwo];
            potionTwo.color = Color.white;
            print(idTwo);
        }
    }
}
