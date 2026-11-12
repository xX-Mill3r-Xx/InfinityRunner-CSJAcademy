using UnityEngine;

public static class Logic 
{
    public static void UpdateFollow(Transform player, Transform camera, float speed, float offSet)
    {
        Vector3 newCamPos = new Vector3(
            player.position.x + offSet, 
            0.0f, 
            camera.position.z);

        camera.position = Vector3.Slerp(
            camera.position,
            newCamPos,
            speed * Time.deltaTime);
    }
}
