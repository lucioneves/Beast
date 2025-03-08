using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] destinations;

    int currentIndex = 0;
    Animator animator;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destinations.Length == 0)
        {
            animator.SetBool("b_isWalkin", false);
            return;
        }

        animator.SetBool("b_isWalkin", true);

        var currentDestination = destinations[currentIndex];

        sprite.flipX = currentDestination.position.x > transform.position.x;

        transform.position = Vector3.MoveTowards(
            transform.position,
            currentDestination.position,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentDestination.position) <= 0.1f)
        {
            currentIndex = (currentIndex + 1) % destinations.Length;
        }
    }
}
