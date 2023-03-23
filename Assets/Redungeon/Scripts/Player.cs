using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // —————————— fields
    private CharacterController character;
    private Camera mainCamera;

    private float horizontal;
    private float vertical;
    
    [SerializeField]
    private float speed;
    private Vector3 forward;
    private Vector3 right;
    private Vector3 gravity;
    private Vector3 moveDirection;
    private Vector3 displacement;


    // —————————— unity methods
    private void Start()
    {
        character = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }
    private void Update()
    {
        GetInputs();
        Move();
    }


    
    // —————————— class methods
    private void GetInputs()
    {
        // Lectura de entradas de usuario
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        Transform cameraTransform = mainCamera.transform;
        
        // Cálculo de la dirección del movimiento
        forward = cameraTransform.forward * vertical;
        right = cameraTransform.right * horizontal;
        gravity = Vector3.down * 9.8f;
        moveDirection = forward + right + gravity;
        
        // Cálculo del desplazamiento
        displacement = moveDirection * (Time.deltaTime * speed);
        character.Move(displacement);
    }
}
