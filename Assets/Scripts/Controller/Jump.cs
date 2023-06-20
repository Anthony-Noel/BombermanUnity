using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
//    private CharacterController _characterController;
//    private Vector3 _playerVelocity;
//    private bool _isNotJumping;
//    private float _jumpHeight = 5.0f;
//    private bool _jumpPressed = false;
//    private float _gravity = -9.81f;

    // void Start()
    // {
    //     _characterController = GetComponent<CharacterController>();
    // }

   
    // void Update()
    // {
    //     JumpMovement();
    // }

    // void JumpMovement()
    // {
    //     _isNotJumping = _characterController.isGrounded;

    //     if(_isNotJumping)
    //     {
    //         _playerVelocity.y = 0.0f;
    //     }

    //     if(_jumpPressed && _isNotJumping)
    //     {
    //         _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -1 * _gravity);
    //         _jumpPressed = false;
    //     }

    //     _playerVelocity.y += _gravity * Time.deltaTime;
    //     _characterController.Move(_playerVelocity * Time.deltaTime);
//     // }

//     void OnJump()
//     {
//         if(_characterController.velocity.y == 0)
//         {
//             Debug.Log("jump");
//             _jumpPressed = true;
//         }
//         else
//         {
//             Debug.Log("no jump");
//         }
    // }
}
