using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class LaserRotator : MonoBehaviour
{
    // Update to rotate the laser
    private bool _isRotating;
    [FormerlySerializedAs("rotationSpeed")] public float rotationDuration = 2f;
    // target rotation is 90 degrees
    
    
    public void RotateRight()
    {
        if (_isRotating) return;
        // rotate current rotation plus 90 degrees
        _isRotating = true;
        transform.DOLocalRotate(new Vector3(0, transform.localEulerAngles.y + 90, 0), rotationDuration).OnComplete(() => _isRotating = false);
    }

    public void RotateLeft()
    {
        if (_isRotating) return;
        // rotate current rotation minus 90 degrees
        _isRotating = true;
        transform.DOLocalRotate(new Vector3(0, transform.localEulerAngles.y -90, 0), rotationDuration).OnComplete(() => _isRotating = false);
    }
}
