using UnityEngine;
using UnityEngine.InputSystem;

public static class PlayerInputs
{
    public static bool JumpPressed()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            return true;

        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            return true;

        return false;
    }

    public static void ApplyJumpForce(Rigidbody2D rig, float jumpForce)
    {
        rig.linearVelocity = new Vector2(rig.linearVelocity.x, 0f);
        rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}