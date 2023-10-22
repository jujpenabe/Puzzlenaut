using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Trigger : MonoBehaviour
{
    //Universal Trigger Script
    [SerializeField] private bool destroyOnTriggerEnter;
    [SerializeField] private string tagFilter;
    [SerializeField] private UnityEvent onTriggerEnter;
    [SerializeField] private UnityEvent onTriggerExit;
    private void OnTriggerEnter(Collider other)
    {
        if (!String.IsNullOrEmpty(tagFilter) && !other.CompareTag(tagFilter)) return;
        onTriggerEnter.Invoke();
        if (destroyOnTriggerEnter) Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!String.IsNullOrEmpty(tagFilter) && !other.CompareTag(tagFilter)) return;
        onTriggerExit.Invoke();
    }
}
