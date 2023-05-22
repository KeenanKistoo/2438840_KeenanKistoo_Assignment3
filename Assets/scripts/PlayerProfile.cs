using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    [Header("Scripts:")]
    public PlayerProfile profile;
    public SelectedCharacter character;

    [Header("Player Info:")]
    public int id;
    public string playerName;
    public string playerDescription;
    public string passive;
    public int passiveVal;
    public string tactical;
    public int maxTact;
    public int tacVal;
    public string ability;
    public int abilityDmg;


    public void SelectCharacter()
    {
        character.profile = profile;
    }
}
