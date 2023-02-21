using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public int _value;
    [SerializeField] private TextMeshProUGUI killValue;
    private void Awake()
    {
    }
    void Start()
    {
        _value = 0;
        killValue.text = "" + _value;
    }

    public void ScoreAdd()
    {
        _value += 1;
        killValue.text = "" + _value;

    }

}
