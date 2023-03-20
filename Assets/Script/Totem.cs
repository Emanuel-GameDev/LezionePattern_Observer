using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    public GameEvent OnTotemLimitCrossed;

    private bool canbeActivated = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!canbeActivated)
            return;

        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                QuestManager.instance.totemQuestCompleted = true;
                canbeActivated = false;
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (QuestManager.instance.totemQuestCompleted == true || !canbeActivated) return;

        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            OnTotemLimitCrossed?.Notify(this, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (QuestManager.instance.totemQuestCompleted == true || !canbeActivated) return;

        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            OnTotemLimitCrossed?.Notify(this, false);
        }
    }

    public void TriggerTotem(Component sender, object data)
    {
        if (sender is not QuestManager)
            return;

        canbeActivated = (bool)data;
    }
}
