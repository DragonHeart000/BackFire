using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMoter : MonoBehaviour {

    private Vector3 vel = Vector3.zero;
    private Vector3 rot = Vector3.zero;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        Screen.lockCursor = true;
	}
	
	void FixedUpdate () {
        DoMove();
        DoRot();
	}

    public void Move(Vector3 vel)
    {
        this.vel = vel;
    }

    private void DoMove()
    {
        if (vel != Vector3.zero)
        {
            rb.MovePosition(transform.position + vel * Time.fixedDeltaTime);
        }
    }

    public void Rotate(Vector3 rot)
    {
        this.rot = rot;
    }

    private void DoRot()
    {
        rb.MoveRotation(transform.rotation * Quaternion.Euler(rot));
    }
}
