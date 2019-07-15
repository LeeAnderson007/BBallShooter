using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "SceneManagement/Pause")]
public class Pause : ScriptableObject
{
    public void TimeChange()
    {
        Time.timeScale = 0;
    }
}
