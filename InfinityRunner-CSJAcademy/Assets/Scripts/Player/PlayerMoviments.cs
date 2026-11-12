using UnityEngine;

public static class PlayerMoviments 
{
    public static void MovePlayer(Rigidbody2D rigidbody, float speed)
    {
        rigidbody.linearVelocity = new Vector2(speed, rigidbody.linearVelocity.y);
    }
}
