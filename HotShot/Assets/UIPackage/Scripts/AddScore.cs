using UnityEngine;

public class AddScore : MonoBehaviour
{
    IntSO addNewScore;
    private void OnTriggerEnter(Collider other)
    {
         addNewScore.Value += 1;
    }
    
}
