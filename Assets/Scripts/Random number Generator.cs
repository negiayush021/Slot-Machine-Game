using UnityEngine;

public class RandomnumberGenerator : MonoBehaviour
{
    public static RandomnumberGenerator instance;
    private void Awake()
    {
        instance = this;
    }
    public int GetRandomIndex(int count)
    {
        return Random.Range(0, count);
    }
}
