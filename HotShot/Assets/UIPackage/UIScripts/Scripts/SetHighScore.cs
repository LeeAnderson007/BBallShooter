using UnityEngine;
using UnityEngine.UI;

public class SetHighScore : MonoBehaviour
{
    public GameObject scoreText;
    public IntSO score;
    void OnTriggerEnter(Collider other)
    {
        score.Value += 1;
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "HighScore: " + score.Value;
    }
}
