using UnityEngine;

[CreateAssetMenu(menuName = "Coroutines/Wait For Seconds")]
public class WaitForSecondsObj : ScriptableObject, IWait
{
    public float Seconds = 1;
    
    public object Obj { get; set; }

    public void Create()
    {
        Obj = new WaitForSeconds(Seconds);
    }
}
    
public interface IWait
{
    object Obj { get; set; }
    void Create();
}