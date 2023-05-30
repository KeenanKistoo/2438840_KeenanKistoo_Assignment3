using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoisonPlayer : MonoBehaviour
{
    public Slider healthBar;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("poisoned");
            healthBar.value -= 1f;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("still poisoned");
            healthBar.value -= 1f * Time.deltaTime;
            player.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
