using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] CountManager _countManager;
    public TextMeshProUGUI CounterText;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        _countManager.Count += 1;
        CounterText.text = "Count : " + _countManager.Count;
    }
}
