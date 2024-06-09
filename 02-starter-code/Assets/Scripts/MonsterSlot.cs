using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSlot : MonoBehaviour
{
    public MonsterData MonsterPrefab;
    private MonsterData placedMonster = null;

    void OnMouseUp()
    {
        if (placedMonster == null)
        {
            if (CanPlaceMonster())
            {
                PlaceMonster();
            }

        }
        else if (CanUpgradeMonster())
        {
            UpgradeMonster();
        }
    }

    private bool CanUpgradeMonster()
    {
        // This is a conditional that checks multiple things:
        // - Is there a monster currently placed?
        // - Does that monster have another level available? (it's not maxxed out)
        // - Do we have enough gold to perform an upgrade?
        // All of these conditions have to be true for this function to return true,
        // otherwise it will return false.
        return placedMonster != null &&
            placedMonster.GetNextLevel() != null &&
            GameManager.Instance.Gold >= placedMonster.GetNextLevel().cost;
    }

    public void UpgradeMonster()
    {
        placedMonster.IncreaseLevel();
        GameManager.Instance.Gold -= placedMonster.CurrentLevel.cost;
    }

    private bool CanPlaceMonster()
    {
        return placedMonster == null && GameManager.Instance.Gold >= MonsterPrefab.levels[0].cost;
    }

    public void PlaceMonster()
    {
        placedMonster = Instantiate(MonsterPrefab, transform.position, Quaternion.identity);
        GameManager.Instance.Gold -= MonsterPrefab.levels[0].cost;
    }
}