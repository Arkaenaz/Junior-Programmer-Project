using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private GameObject _objectToDrop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropObject();
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, 5) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(0, 0, 5) * Time.deltaTime;
        }
    }

    void DropObject()
    {
        Instantiate(_objectToDrop, transform.position - new Vector3(0, 1), _objectToDrop.transform.rotation);
    }
}
