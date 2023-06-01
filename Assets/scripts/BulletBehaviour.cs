using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;

    public Transform player;
    public Vector2 target;

    public Slider healthBar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

        speed = 5f;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("player hit");
            Slider bar = GameObject.FindGameObjectWithTag("Healthbar").GetComponent<Slider>();
            bar.value -= 1f;

            

            StartCoroutine(PlayerColour(this.gameObject));
        }
    }

    IEnumerator PlayerColour(GameObject destroyed)
    {
        GameObject.FindGameObjectWithTag("Anim").GetComponent<SpriteRenderer>().color = Color.red;
        destroyed.GetComponent<Transform>().localScale = Vector3.zero;
        yield return new WaitForSeconds(0.25f);

        GameObject.FindGameObjectWithTag("Anim").GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(destroyed);

    }
}
