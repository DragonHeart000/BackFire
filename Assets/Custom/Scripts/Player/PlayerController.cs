using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(PlayerMoter))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    public float lookSensitivity = 2f;

    private PlayerMoter moter;

    private float lungeTime = 0f;
    private float lungeCooldown = 3f;
    public Image lungeIcon;
    public TextMeshProUGUI lungeText;

    // Use this for initialization
    void Start () {
        lookSensitivity = PlayerSettings.getLookSensitivity();

        moter = GetComponent<PlayerMoter>();
        lungeIcon.color = new Color(0f, 200f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorz = transform.right * xMove;
        Vector3 moveVert = transform.forward * zMove;

        Vector3 vel = (moveHorz + moveVert).normalized * speed;

        moter.Move(vel);

        //Rotation
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rot = new Vector3(0f, yRot, 0f) * lookSensitivity;

        moter.Rotate(rot);

        //Lunge
        if (Input.GetKeyDown("space") && Time.time > lungeTime + lungeCooldown)
        {

            if (Input.GetKey("w"))
            {
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if (!Physics.Raycast(ray, out hit, 10))
                {
                    transform.position += transform.forward * 10;
                    lunged();
                }
            } else if (Input.GetKey("s"))
            {
                Ray ray = new Ray(transform.position, -transform.forward);
                RaycastHit hit;

                if (!Physics.Raycast(ray, out hit, 10))
                {
                    transform.position -= transform.forward * 10;
                    lunged();
                }
            } else if (Input.GetKey("a"))
            {
                Ray ray = new Ray(transform.position, -transform.right);
                RaycastHit hit;

                if (!Physics.Raycast(ray, out hit, 10))
                {
                    transform.position += -transform.right * 10;
                    lunged();
                }
            } else if (Input.GetKey("d"))
            {
                Ray ray = new Ray(transform.position, transform.right);
                RaycastHit hit;

                if (!Physics.Raycast(ray, out hit, 10))
                {
                    transform.position += transform.right * 10;
                    lunged();
                }
            } else
            {
                //Forward default
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if (!Physics.Raycast(ray, out hit, 10))
                {
                    transform.position += transform.forward * 10;
                    lunged();
                }
            }
        }
	}

    private void lunged()
    {
        lungeTime = Time.time;
        lungeIcon.color = new Color(256f, 256f, 256f);
        StartCoroutine("lungeTextCooldown");
    }

    IEnumerator lungeTextCooldown()
    {
        for (int i = 3; i > 0; i--)
        {
            lungeText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        lungeText.text = "Ready";
        lungeIcon.color = new Color(0f, 200f, 0f);
    }
}
