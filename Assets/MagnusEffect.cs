using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusEffect : MonoBehaviour
{
    public float kickForce = 1.0f;
    public float spinAmount = 1.0f; // ปรับทิศทางหลังเตะไปแล้ว ซ้าย/ขวา
    public float magnusStrength = 0.5f;
    private Rigidbody _rb;
    private bool _isShoot = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    } 
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !_isShoot)
        {
            // ปรับทิศทางตอนเตะ x, y, z
            _rb.AddForce(-1, 4f, kickForce, ForceMode.Impulse);
            // ให้ลูกบอลหมุนเวลาเคลื่อนที่
            _rb.AddRelativeTorque(Vector3.up * spinAmount);
            _isShoot = true;
        }
    }
    void FixedUpdate()
    {
        if (!_isShoot) return;
        Vector3 velocity = _rb.linearVelocity;
        Vector3 spin = _rb.angularVelocity;
        // Cross Product หาทิศทางใหม่ให้บอลเคลื่อนที่ไป
        Vector3 magnusForce = Vector3.Cross(spin, velocity);
        magnusForce *= magnusStrength;
        _rb.AddForce(magnusForce);
    }
}
