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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destinations.Length == 0)
        {
            animator.SetBool("b_isWalking", false);
            return;
        }

        animator.SetBool("b_isWalking", true);

        var currentDestination = destinations[currentIndex];

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
