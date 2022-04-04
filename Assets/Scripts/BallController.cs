using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float ImpulseForce = 3f;

    private bool IgnoreNextcollision;

    private void OnCollisionEnter(Collision collision)
    {

        {
            if (IgnoreNextcollision)
            {
                return;
            }
            GameManager.singleton.AddScore(1);
        }
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*ImpulseForce, ForceMode.Impulse);

        IgnoreNextcollision = true;
        Invoke("AllowNextCollision", 0.2f);
    }

    private void AllowNextCollision()
    {
        IgnoreNextcollision = false;
    }
}
