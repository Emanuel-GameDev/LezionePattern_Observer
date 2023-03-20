using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [Header("Coin Related")]
    public TextMeshProUGUI coinCollectedText;

    [Header("Totem Related")]
    public TextMeshProUGUI totemInteractionText;

    [Header("Quest References")]
    [SerializeField] TextMeshProUGUI questName;
    [SerializeField] GameObject questButtonParent;

    [Header("Player")]
    [SerializeField] private TextMeshProUGUI playerLvlText;

    public void SetupCoinText(Component sender, object data)
    {
        if (sender is not QuestManager || data == null) return;

        coinCollectedText.gameObject.SetActive(true);
        coinCollectedText.text = data.ToString();
    }

    public void TriggerTotemText(Component sender, object data)
    {
        if (sender is not Totem || data is not bool) return;

        totemInteractionText.gameObject.SetActive((bool)data);
    }

    public void UpdatePlayerLvlText(Component sender, object data)
    {
        if (sender is not Player || data is not int) return;

        int num = (int)data;
        playerLvlText.text = "Lvl " + num.ToString();
    }

    public void TriggerUISetup(Component sender, object data)
    {
        if (sender is not QuestManager || QuestManager.instance.allQuestsCompleted) return;

        questButtonParent.SetActive(!questButtonParent.activeSelf);
        questButtonParent.transform.GetChild(1).gameObject.SetActive(true);

        if (QuestManager.instance.coinQuestCompleted)
        {
            coinCollectedText.gameObject.SetActive(false);
            questName.gameObject.SetActive(false);
            questButtonParent.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (QuestManager.instance.totemQuestCompleted)
        {
            totemInteractionText.gameObject.SetActive(false);
            questButtonParent.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UpdateCoinText(Component sender, object data)
    {
        if (sender is not Coin || data is not int)
            return;

        QuestManager.instance.coinCount += (int)data;
        coinCollectedText.text = QuestManager.instance.coinCount.ToString();
    }
}
