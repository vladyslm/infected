using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private Collider _trigger;

    private void Awake()
    {
        _trigger = transform.GetComponent<Collider>();
    }


    public void TurnOnTrigger()
    {
        _trigger.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}