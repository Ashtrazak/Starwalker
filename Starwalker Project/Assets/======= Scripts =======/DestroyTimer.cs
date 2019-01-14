using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float destroyTime;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }	
}
