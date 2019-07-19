
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class LevelController : ScriptableObject
{
    public UnityAction StartAction;

    [SerializeField] public List<Level> Levels;
        [SerializeField] public List<wordLevel> WordLevels;
        public List<WordGroup> WordGroupList;
        
        public int currentLevel = 0;

        public void OnStartLevel()
        {
            StartAction?.Invoke();
        }
        
        public void OnCompleteLevel()
        {
            currentLevel++;

            if (currentLevel == 1)
            {
                UnlockLevels();
            }
        }
        
        private void UnlockLevels()
        {
            for (var index = Levels.Count - 1; index >= 0; index--)
            {
                var levelLock = Levels[index];
                levelLock.locked = false;
            }
        }
}

[System.Serializable]
public struct Level
{
    public bool locked;
    public float power;
    public int enemyCount;
    public string levelTitle;
    public GameObject player;
    public List<ScriptableObject> gameConfigs;
}

[System.Serializable]
public struct wordLevel
{
    public List<string> Words;
}