using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterLevel
{
    public int cost; // How much it costs to go to this level (we will implement this later)
    public GameObject visualization; // A GameObject that is a child of the monster. There are 3 on the provided prefab.
}

public class MonsterData : MonoBehaviour
{
    public List<MonsterLevel> levels;

    private MonsterLevel currentLevel;

    public void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    public MonsterLevel CurrentLevel
    {

        get { return currentLevel; }

        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            // Finds the visualization associated with the current level.
            GameObject levelVisualization = levels[currentLevelIndex].visualization;

            // Iterates over each level.
            for (int i = 0; i < levels.Count; i++)
            {
                // Sanity check to make sure this level actually has a visualization.
                if (levelVisualization != null)
                {
                    // If we're considering the current level, make the visualization active
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else
                    {
                        // Otherwise, make it inactive (if we didn't do this, the old visualization would stay active when you level up.)
                        levels[i].visualization.SetActive(false);
                    }
                }
            }
        }

    }

    public MonsterLevel GetNextLevel()
    {
        // Gives us the index of the current level, which we can use to access the next one.
        int currentLevelIndex = levels.IndexOf(currentLevel);
        // Checks to make sure we're not already at the max level.
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            // Gives us the next level in our levels list.
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }

    public void IncreaseLevel()
    {
        // Gives us the index of the current level, which we can use to access other levels.
        int currentLevelIndex = levels.IndexOf(currentLevel);
        // Checks to make sure we're not already at the max level.
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
}
