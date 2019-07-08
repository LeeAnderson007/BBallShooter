using UnityEngine;
using UnityEngine.UI;

public class SetHighScore : MonoBehaviour
{
    public GameObject scoreText;
    public IntSO score;
    void OnTriggerEnter(Collider other)
    {
        if (score != null)
        {
            score.Value += 1;
            if (scoreText != null) scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "HighScore: " + score.Value;
        }
    }
}
