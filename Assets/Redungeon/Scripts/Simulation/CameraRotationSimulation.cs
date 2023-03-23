using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationSimulation : MonoBehaviour
{
#if (UNITY_EDITOR)
    // ———————————————————— fields
    private Vector2 mouseInput = Vector2.zero;
    
    [SerializeField]
    private float mouseSensitivity = 200;
    private Vector2 rotation = Vector2.zero;
    


    // ———————————————————— unity methods
    private void Start()
    {
        // Ocultamos y bloqueamos el cursor para disminuir errores en los test.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        // Leemos las entradas del cursor.
        mouseInput.x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseInput.y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Realizamos los cálculos de rotación y limitamos el eje vertical.
        rotation.x -= mouseInput.y;
        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);
        
        rotation.y += mouseInput.x;

        // Aplicamos los cálculos de rotación.
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
    }
#endif
}
