using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Player characterMovement;
    [SerializeField] private PhotoGraphy photoGraphy;
    [SerializeField] private Transform followingTarget;
    private void Awake()
    {
        characterMovement = GetComponent<Player>();
        photoGraphy.InitCamera(followingTarget);
    }

    private void Update()
    {
        UpdateMovementInput();
    }
    private void UpdateMovementInput()
    {
        Quaternion quaternion = Quaternion.Euler(0, photoGraphy.Yaw, 0);
         
        characterMovement.SetMovementInput(quaternion * Vector3.forward * Input.GetAxis("Vertical") + quaternion*Vector3.right * Input.GetAxis("Horizontal"));
    }
}
