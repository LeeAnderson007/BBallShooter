using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    public GameObject scoreText;
    public int score;
    void OnTriggerEnter(Collider other)
    {
        score += 1;
        if (scoreText != null) scoreText.GetComponent<Text>().text = "Score: " + score;
    }
}
