using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BackToPosition : MonoBehaviour
{
    // using dotween move to target position after a delay
    public Vector3 targetPosition;
    public float delay = 1f;
    public float duration = 1f;
    void Start()
    {
        transform.DOMove(targetPosition, duration).SetDelay(delay);
    }
}
