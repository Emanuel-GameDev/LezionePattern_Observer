using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameEvent OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            OnCoinCollected.Notify(this, 1);
            Destroy(gameObject);
        }
    }
}
