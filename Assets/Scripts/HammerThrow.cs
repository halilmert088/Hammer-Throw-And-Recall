using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerThrow : MonoBehaviour
{
    public Transform hammer;
    public Transform target;
    public Rigidbody rb;
    public bool hasHammer = true;
    public bool isReturning = false;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = hammer.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && hasHammer == true)
        {
            Throw();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && hasHammer == false)
        {
            Return();
        }

        if(isReturning)
        {
            if(time < 1.0f)
            {
                hammer.position += (target.position - hammer.position) * 10f * Time.deltaTime;
                hammer.rotation = Quaternion.Slerp(hammer.transform.rotation, target.rotation, 50 * Time.deltaTime);
                time += Time.deltaTime;
            }

            else
            {
                Reset();
            }
        }
    }

    public void Throw()
    {
        hasHammer = false;
        rb.isKinematic = false;
        hammer.transform.parent = null;
        rb.AddForce(Camera.main.transform.forward * 30f, ForceMode.Impulse);
    }

    public void Return()
    {
        time = 0.0f;
        isReturning = true;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }

    public void Reset()
    {
        isReturning = false;
        hasHammer = true;
        hammer.transform.parent = Camera.main.transform;
        hammer.position = target.position;
        hammer.rotation = target.rotation;
    }
}
