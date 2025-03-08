using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContactHandler : MonoBehaviour
{
    public Image itemImage;

    bool canWinLevel = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("PLAYER TOCOU NO INIMIGO ENTÃO PERDEU !!!!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("PLAYER PEGOU O ITEM");
            Destroy(collision.gameObject);
            itemImage.color = Color.white;
            canWinLevel = true;
        }

        if (collision.gameObject.CompareTag("FinalPoint"))
        {
            if (canWinLevel)
            {
                Debug.Log("PLAYER GANHOU O LEVEL");
            }
            else
            {
                Debug.Log("PLAYER NÃO GANHOU O LEVEL");
            }
        }
    }
}
