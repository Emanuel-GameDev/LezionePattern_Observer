using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameEvent OnPlayerLevelUp;

    public int expToLvlUp = 100;
    private int currentExp;
    private int lvl = 0;   

    private void Update()
    {
        if (currentExp >= expToLvlUp)
        {
            lvl++; 
            OnPlayerLevelUp?.Notify(this, lvl);
            expToLvlUp += currentExp;
        }
    }

    public void UpdateExp(Component sender, object data)
    {
        if (sender is not QuestManager || data is not int) return;

        currentExp += (int)data;
    }
}
