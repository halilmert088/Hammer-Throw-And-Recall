using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");
    }
}
