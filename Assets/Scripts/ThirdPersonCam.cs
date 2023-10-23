using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform  player;
    public Transform  playerObj;
    public Rigidbody  rb;

    public float rotationSpeed;

    private void Start(){
    
    }
    private void Update(){
        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        

        // get angle of player local up vector with viewdir vector
        // float angle = Vector3.Angle(playerObj.up, viewDir);
        // Debug.Log(angle);
        
        // Show the angle in the inspector
        
        //flat viewdir cextor with perpedincular of player up vector
        Vector3 flatViewDir = Vector3.ProjectOnPlane(viewDir, playerObj.up);
        orientation.rotation = Quaternion.LookRotation(flatViewDir.normalized, playerObj.up);
        // Show the angle in the inspector and a ray   
        Debug.DrawRay(player.position, flatViewDir, Color.red);
        Debug.Log(Vector3.Angle(playerObj.up, flatViewDir)); 
        Debug.Log(Vector3.Angle(playerObj.up, viewDir));
        
        // slerp rotate the playerObj to the same angle as the orientation
        playerObj.rotation = Quaternion.Slerp(playerObj.rotation, orientation.rotation, Time.deltaTime * rotationSpeed);
        
        // rotate player object
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //
        // if (inputDir != Vector3.zero){
        //     playerObj.forward = Vector3.Slerp(playerObj.forward, flatViewDir.normalized, Time.deltaTime * rotationSpeed);
        // }
        
        
    }
}
