using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    
    public void GatherInputs(out Vector3 inputVector)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        inputVector = new Vector3(horizontal, 0f, vertical).normalized;
    }

}