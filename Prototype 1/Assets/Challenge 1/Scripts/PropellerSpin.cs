using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    [SerializeField] private float _spinSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _spinSpeed * Time.deltaTime);
    }
}
