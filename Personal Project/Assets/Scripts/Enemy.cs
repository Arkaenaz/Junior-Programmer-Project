using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _rangeY = -10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBounds();
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.y < _rangeY)
        {
            Debug.Log("Player out of bounds, destroying player.");
            Destroy(gameObject);
        }
    }
}
