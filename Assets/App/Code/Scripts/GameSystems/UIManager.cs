using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Data")] [SerializeField] private Counters counters;

    [Header("UI Elements")] [SerializeField]
    private TextMeshProUGUI infectedCounter;

    [SerializeField] private TextMeshProUGUI cleanCounter;
    [SerializeField] private TextMeshProUGUI cleanersCounter;


    public void OnUpdateUI()
    {
        infectedCounter.text = $"{counters.infected}";
        cleanCounter.text = $"{counters.clean}";
        cleanersCounter.text = $"{counters.cleaners}";
    }
}