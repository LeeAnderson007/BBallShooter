using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WordGroup : ScriptableObject
{
    public bool LevelLocked = true;
    public List<string> WordList;
}
