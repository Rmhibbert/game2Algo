using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSlot : MonoBehaviour
{
    public GameObject MonsterPrefab;
    private GameObject placedMonster = null; 

    void OnMouseUp()
    {
        if (placedMonster == null)
        {
            placedMonster = (GameObject)Instantiate(MonsterPrefab, transform.position, Quaternion.identity);
        }
        else if (CanUpgradeMonster())
        {
            placedMonster.GetComponent<MonsterData>().IncreaseLevel();
        }
    }

    private bool CanUpgradeMonster()
    {
        if (placedMonster != null)
        {
            MonsterData monsterData = placedMonster.GetComponent<MonsterData>();
            MonsterLevel nextLevel = monsterData.GetNextLevel();
            if (nextLevel != null)
            {
                return true;
            }
        }
        return false;
    }

}
