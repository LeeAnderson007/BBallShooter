using UnityEngine;
using UnityEngine.UI;

public class SetHighScore : MonoBehaviour
{
    public GameObject scoreText;
    public IntSO score;
    void OnTriggerEnter(Collider other)
    {
        score.Value += 1;
        scoreText.GetComponent<Text>().text = "HighScore: " + score.Value;
    }
}
