using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum QuestType { 
    Coin,
    Totem
}

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    [Header("Quest General")]
    public GameEvent OnQuestCompleted;
    [HideInInspector] public bool allQuestsCompleted = false;

    [Header("Coin quest")]
    public GameEvent OnCoinQuestActivated;
    [HideInInspector] public int coinCount = 0; 
    public int coinNeededToComplete = 4;
    [HideInInspector] public bool coinQuestCompleted = false;
    public int coinQuestExp = 100;

    [Header("Totem quest")]
    [HideInInspector] public bool totemQuestCompleted = false;
    public GameEvent OnTotemQuestActivated;
    public int totemQuestExp = 150;

    private void Awake()
    {
        if (instance == null)   
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (coinCount == coinNeededToComplete)
        {
            Debug.Log("Coin Quest completed");
            coinQuestCompleted = true;
            OnQuestCompleted?.Notify(this, coinQuestExp);
            coinCount = 0;
        }
        else if (totemQuestCompleted && !allQuestsCompleted)
        {
            Debug.Log("Totem quest completed");
            OnQuestCompleted?.Notify(this, totemQuestExp);
        }
        
        if ((coinQuestCompleted || totemQuestCompleted) && totemQuestCompleted)
            allQuestsCompleted = true;
    }

    public void ActivateQuest(int typeInt)
    {
        switch((QuestType)typeInt)
        {
            case QuestType.Coin:
                if (coinQuestCompleted)
                    return;
                Debug.Log("Quest coin attivata");
                OnCoinQuestActivated?.Notify(this, 0);
                break;
            case QuestType.Totem:
                Debug.Log("Quest totem attivata");
                OnTotemQuestActivated?.Notify(this, true);
                break;
        }
    }


}
