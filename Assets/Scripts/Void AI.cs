using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public Transform teleportTarget; // The target position to teleport to

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HitBox")) // Check if the collided object has the tag "HitBox"
        {
            transform.position = teleportTarget.position; // Teleport to the target position
            print("SIGMA");
        }
    }
}
