using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update

    public int movementSpeed = 100;
    private Rigidbody myRigidBody;
    private Camera myCamera;
    public GameObject bulletPrefab;
    public float fireDelay = .1f;
    private float delayBeforeNextFire = 0;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        MovePlayer();
        OrientedPlayer();
        ProccessFire();
    }


    private void MovePlayer()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputHorizontal, 0, inputVertical) * Time.deltaTime * movementSpeed;
        myRigidBody.MovePosition(myRigidBody.position + movement);
    }

    private void OrientedPlayer()
    {
        Vector3 result = FindPositionOfMouse();
        result.y = myRigidBody.position.y;
        Vector3 relativePosition = result - transform.position;
        Quaternion quaternionRotation = Quaternion.LookRotation(relativePosition, Vector3.up);
        myRigidBody.MoveRotation(quaternionRotation);
    }

    private void ProccessFire()
    {
        delayBeforeNextFire -= Time.deltaTime;
        if (Input.GetAxis("Fire1")!=0)
        {
            if (delayBeforeNextFire <= 0)
            {
                //shoot
                ShootBullet();
                delayBeforeNextFire = fireDelay;
            }
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
    }

    private Vector3 FindPositionOfMouse()
    {
        Vector3 result = Vector3.zero;
        RaycastHit hit;
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            result.x = hit.point.x;
            result.y = hit.point.y;
            result.z = hit.point.z;
        }
            return result; 
    }


}
