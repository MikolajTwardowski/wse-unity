using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    CharacterController characterController;
    Camera mainCam;
    Vector3 direction;
    Vector3 mouseWordPosition;
    [SerializeReference] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        UppdateMouseWordPosition();
        UppdateDirection();
        LookAtCursor();
    }

    private void FixedUpdate() {
        if(Input.GetMouseButton(0))
            FollowCursor();
    }

    void FollowCursor()
    {
        characterController.Move(direction * speed );
    }


    void UppdateMouseWordPosition()
    {
        mouseWordPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mouseWordPosition.y = 0;
    }

    void UppdateDirection()
    {
        direction = mouseWordPosition - transform.position;
        direction.y = 0;
    }

    void LookAtCursor()
    {
        transform.LookAt(mouseWordPosition);
    }
}
