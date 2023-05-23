using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerProfile : MonoBehaviour
{
    [Header("Scripts:")]
    public PlayerProfile profile;
    public SelectedCharacter character;
    public PlayerMovement move;


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

    [Header("Animator:")]
    public RuntimeAnimatorController anim;
    public Animator animCon;

    [Header("Bullet:")]
    public GameObject bulletPrefab;
    public Shooting shooting;


    public void SelectCharacter()
    {
        character.profile = profile;
        animCon.runtimeAnimatorController = anim;
        shooting.bulletPrefab = bulletPrefab;
        
    }
}
