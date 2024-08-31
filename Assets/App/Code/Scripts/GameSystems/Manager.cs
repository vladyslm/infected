using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private AllRoles allRoles;
    [SerializeField] private Counters counters;
    [Header("Events")] [SerializeField] private UnityEvent onUpdateCounters;
    [SerializeField] private UnityEvent onLevelComplete;

    private int _cleaned = 0;
    private int _clean = 0;
    private int _infected = 0;

    private Role[] _roles = { };

    private void Awake()
    {
        ResetCounters();
    }

    void Start()
    {
        _roles = FindObjectsOfType<Role>();
        CalculateRoles();
    }


    private void CalculateRoles()
    {
        ResetStats();
        foreach (var role in _roles)
        {
            if (role.RoleTargets == allRoles.clean)
            {
                _clean += 1;
                continue;
            }

            if (role.RoleTargets == allRoles.cleaner)
            {
                _cleaned += 1;
                continue;
            }

            if (role.RoleTargets == allRoles.infected)
            {
                _infected += 1;
            }
        }

        UpdateCounters();
    }

    private void ResetStats()
    {
        _cleaned = 0;
        _clean = 0;
        _infected = 0;
    }

    private void ResetCounters()
    {
        counters.infected = 0;
        counters.clean = 0;
        counters.cleaners = 0;
    }

    private void UpdateCounters()
    {
        counters.infected = _infected;
        counters.clean = _clean;
        counters.cleaners = _cleaned;
        onUpdateCounters?.Invoke();
        if (_infected == (_roles.Length - 1))
        {
            onLevelComplete?.Invoke();
        }
    }

    public void OnInfection()
    {
        CalculateRoles();
    }
}