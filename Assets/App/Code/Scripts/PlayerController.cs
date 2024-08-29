using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private InputActionReference movementAction;
    [SerializeField] private InputActionReference look;
    

    [SerializeField] private float speed;
    [SerializeField] private float acceleration = 200f;
    
    private Vector2 _direction = Vector2.zero;


    private void Awake()
    {
        movementAction.action.performed += OnActionMove;
        movementAction.action.canceled += OnActionMoveEnd;

        // look.action.performed += OnLookAction;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void OnActionMove(InputAction.CallbackContext ctx)
    {
        _direction = ctx.ReadValue<Vector2>();
        // Debug.Log(_direction);
    }

    private void OnActionMoveEnd(InputAction.CallbackContext _)
    {
        _direction = Vector2.zero;
    }

    // private void MovePlayer()
    // {
    //     var forward = playerCamera.transform.forward.normalized;
    //     var right = playerCamera.transform.right.normalized;
    //
    //     var forwardRel = _direction.y * forward;
    //     var rightRel = _direction.x * right;
    //     
    //
    //     var cameraRelatedDirection = (forwardRel + rightRel) * speed;
    //     // var cameraRelatedDirection = (forwardRel + rightRel);
    //     rigidBody.velocity = new Vector3(cameraRelatedDirection.x, rigidBody.velocity.y, cameraRelatedDirection.z);
    //     // rigidBody.AddForce(cameraRelatedDirection.x * speed * Time.deltaTime, rigidBody.velocity.y,cameraRelatedDirection.z * speed * Time.deltaTime);
    //     
    //     
    //     // rigidBody.AddForce(cameraRelatedDirection);
    // }
    
    // TODO: update 
    private void MovePlayer()
    {
        var unitGoal = GetCameraRelativeDirection();

        var maxVel = unitGoal * speed;
        var goalVel = Vector3.MoveTowards(rigidBody.velocity, maxVel, acceleration);

        var neededAccel = goalVel - rigidBody.velocity;
        
        rigidBody.AddForce(neededAccel);
    }

    private Vector3 GetCameraRelativeDirection()
    {
        var forward = playerCamera.transform.forward.normalized;
        var right = playerCamera.transform.right.normalized;

        var forwardRel = _direction.y * forward;
        var rightRel = _direction.x * right;
        return (forwardRel + rightRel).normalized;
    }
}
