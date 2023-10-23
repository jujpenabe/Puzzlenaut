using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class AnimateIntro : MonoBehaviour
{
    // Get CineMachine FreeLook Camera
    public GameObject freeLookCam;
    // Get Player
    public GameObject player;
    // Get Spaceship
    public GameObject spaceship;
    // Get Orientation empty object
    public GameObject orientation;
    
    private CinemachineFreeLook freeLookCamComponent;

    private void Awake()
    {
        freeLookCamComponent = freeLookCam.GetComponent<Cinemachine.CinemachineFreeLook>();
    }

    private void Start()
    {
        // set the camera to follow the spaceship
        freeLookCamComponent.Follow = spaceship.transform;
        
    }
}
