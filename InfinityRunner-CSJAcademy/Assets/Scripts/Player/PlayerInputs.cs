using UnityEngine;
using UnityEngine.InputSystem;

public static class PlayerInputs
{
    public static void InputsMoviment(Rigidbody2D rig, float jumpForce)
    {
        bool jumpPressed = false;

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            jumpPressed = true;

        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            jumpPressed = true;

        if (jumpPressed)
            AddJumpForce(rig, jumpForce);
    }

    private static void AddJumpForce(Rigidbody2D rig, float jumpForce)
    {
        rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
