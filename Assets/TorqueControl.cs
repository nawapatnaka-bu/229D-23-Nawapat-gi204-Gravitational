using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TorqueControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float torquePower = 1f;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Keyboard.current.dKey.isPressed)
        {
            _rb.AddTorque(0, torquePower, 0);
        }
    }
}
