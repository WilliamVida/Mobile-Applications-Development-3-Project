using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://github.com/mixandjam/StarFox-RailMovement
public class PlayerMovement : MonoBehaviour
{

    private Transform playerModel;
    [Space]

    [Header("Parameters")]
    public float xySpeed = 12;
    public float lookSpeed = 10000;

    [Space]

    [Header("Public References")]
    public Transform aimTarget;

    void Start()
    {
        Application.targetFrameRate = 100;
        playerModel = transform.GetChild(0);
    }

    void Update()
    {
        // float h = joystick ? Input.GetAxis("Horizontal") : Input.GetAxis("Mouse X");
        // float v = joystick ? Input.GetAxis("Vertical") : Input.GetAxis("Mouse Y");

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        LocalMove(h, v, xySpeed);
        RotationLook(h, v, lookSpeed);
        HorizontalLean(playerModel, h, 80, 0.1f);
    }

    void LocalMove(float x, float y, float speed)
    {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
        ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void RotationLook(float h, float v, float speed)
    {
        aimTarget.parent.position = Vector3.zero;
        aimTarget.localPosition = new Vector3(h, v, 1);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed * Time.deltaTime);
    }

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
    }

}
