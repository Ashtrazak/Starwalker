using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [Header("Время жизни объекта")]
    [Range(0f, 1000f)]
    public float lifeTime;

	void Awake ()
    {
        Destroy(gameObject, lifeTime);
	}

}
