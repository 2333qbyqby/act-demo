using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    

    public Vector3 currentInput { get; private set; }
    public float walkspeed=5;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position+currentInput*walkspeed*Time.fixedDeltaTime);
    }

    public void SetMovementInput(Vector3 input)
    {
       currentInput = Vector3.ClampMagnitude(input, 1);
    }
}
