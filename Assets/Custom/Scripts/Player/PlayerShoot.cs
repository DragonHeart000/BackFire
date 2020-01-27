using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerShoot : NetworkBehaviour {

    public LineRenderer line;
    public LineRenderer aimingLine;

    private bool showAimingLine = true;

    private float fireStart = 0f;
    private float fireRate = 1f;
    private float fireVisualTime = 0.2f;

    private GameObject otherPlayer;

    private int localScore;
    private int enemyScore;
    public Text scoreText;

    private void Start()
    {
        line.enabled = false;

        //Can't shoot right away to give grace time in case spawned in front of one another
        fireStart = Time.time;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && (Time.time > fireStart + fireRate))
        {
            fireStart = Time.time;
            line.enabled = true;
            Shoot();
        } else if(Time.time > fireStart + fireVisualTime)
        {
            line.enabled = false;
        }

        if (Input.GetKeyDown("f"))
        {
            if (showAimingLine)
                aimingLine.enabled = false;
            else
                aimingLine.enabled = true;

            showAimingLine = !showAimingLine;
        } else if (Input.GetKeyDown("g"))
        {
            //To allow for line to stay where it was
            showAimingLine = !showAimingLine;
            aimingLine.enabled = true;
        } else if (showAimingLine)
        {
            aimVisual();
        }
        
    }

    private void Shoot()
    {
        Ray ray = new Ray(otherPlayer.transform.position, otherPlayer.transform.forward);
        RaycastHit hit;

        line.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Player")
            {
                Debug.Log("Hit Player");
                upLocalScore();
            }
            else
            {
                Ray ray2 = new Ray(hit.point, hit.normal);
                RaycastHit hit2;

                if (Physics.Raycast(ray2, out hit2, 100))
                {
                    if (hit2.transform.tag == "Player")
                    {
                        Debug.Log("Hit Player");
                        upLocalScore();
                    }
                    else
                    {
                        Ray ray3 = new Ray(hit2.point, hit2.normal);
                        RaycastHit hit3;

                        if (Physics.Raycast(ray3, out hit3, 100))
                        {
                            if (hit2.transform.tag == "Player")
                            {
                                Debug.Log("Hit Player");
                                upLocalScore();
                            }

                            //Third
                            line.SetPosition(3, hit3.point);
                        }
                    }

                    //Second
                    line.SetPosition(2, hit2.point);
                }
            }
                //First
                line.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(100));
        }
    }

    private void aimVisual()
    {
        Vector3 vec = transform.position;
        vec.y = 1;

        Ray ray = new Ray(vec, transform.forward);
        RaycastHit hit;

        aimingLine.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag != "Player")
            {
                Ray ray2 = new Ray(hit.point, hit.normal);
                RaycastHit hit2;

                if (Physics.Raycast(ray2, out hit2, 100))
                {
                    if (hit2.transform.tag != "Player")
                    {
                        Ray ray3 = new Ray(hit2.point, hit2.normal);
                        RaycastHit hit3;

                        if (Physics.Raycast(ray3, out hit3, 100))
                        {
                            //Third
                            aimingLine.SetPosition(3, hit3.point);
                        }
                    }
                    //Second
                    aimingLine.SetPosition(2, hit2.point);
                }
            }
            //First
            aimingLine.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(100));
        }
    }

    private void SingleShot()
    {
        Ray ray = new Ray(otherPlayer.transform.position, otherPlayer.transform.forward);
        RaycastHit hit;

        line.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, 100))
        {
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(100));
        }
    }

    public void setOpponent(GameObject toSet)
    {
        otherPlayer = toSet;
    }

    public void upLocalScore()
    {
        localScore++;
        scoreText.text = localScore + " : " + enemyScore;
        //Tell enemy I scored
        otherPlayer.GetComponent<PlayerShoot>().upEnemyScore();
    }

    public void upEnemyScore()
    {
        enemyScore++;
        scoreText.text = localScore + " : " + enemyScore;
    }
}
