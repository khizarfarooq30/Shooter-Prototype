using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private LayerMask groundLayer;

    private Camera mainCam;
    private Rigidbody rb;
    private PlayerInputs playerInputs;
    private PlayerAnimation playerAnimation;

    private Vector3 inputVector;
    
    private void Awake()
    {
        mainCam = Camera.main;
        playerAnimation = GetComponent<PlayerAnimation>();
        playerInputs = GetComponent<PlayerInputs>();
        rb = GetComponent<Rigidbody>();
    }

    public void ProcessMove()
    {
        playerInputs.GatherInputs(out inputVector);
        playerAnimation.HandleMovementAnimation(inputVector);
        LookTowardsMousePoint();
    }

    public void Move()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * inputVector);
    }

    private void LookTowardsMousePoint()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, groundLayer))
        {
            var direction = hitInfo.point - transform.position;
            direction.Normalize();
            direction.y = 0f;
            float lerpSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * lerpSpeed);
        }
    }
}
