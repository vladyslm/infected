using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class EnemyLocomotion : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private float rotationSpeed = 50;
    [SerializeField] private float upImpulse = 3;


    private Rigidbody _rb;
    private bool _isGrounded = true;
    private bool _isReadyToJump;

    private Vector3 _randDir = Vector3.zero;


    // Start is called before the first frame update
    private void Awake()
    {
        _randDir = GetRandomDirection();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Jump();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, _randDir);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward.normalized);
    }

    private void Jump()
    {
        if (_isReadyToJump)
        {
            var angle = Vector3.Angle(_rb.transform.forward, _randDir);

            if (angle > 5)
            {
                _rb.AddForce(Vector3.up * upImpulse, ForceMode.Impulse);
                _isReadyToJump = false;
                return;
            }

            var jumpDirection = (_rb.transform.forward * speed) + Vector3.up * upImpulse;
            _rb.AddForce(jumpDirection, ForceMode.VelocityChange);
            _isReadyToJump = false;
            _randDir = GetRandomDirection();
        }

        if (!_isGrounded)
        {
            RotatesTowardsTargetDirection();
        }
    }

    private void RotatesTowardsTargetDirection()
    {
        var targetRot = Quaternion.LookRotation(_randDir);
        var smoothRotation = Quaternion.RotateTowards(_rb.rotation, targetRot, rotationSpeed * Time.deltaTime);

        _rb.MoveRotation(smoothRotation);
    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }


    private void OnCollisionStay(Collision other)
    {
        if (!other.transform.CompareTag("Ground")) return;
        _isGrounded = true;
        _isReadyToJump = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}