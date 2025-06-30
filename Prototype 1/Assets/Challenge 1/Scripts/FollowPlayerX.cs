using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    [SerializeField] private GameObject _plane;
    [SerializeField] private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _plane.transform.position + _offset;
    }
}
