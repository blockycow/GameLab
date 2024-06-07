using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    
    void Start()
    {
        TimeManager.Instance.timerText = timer;
    }
}
