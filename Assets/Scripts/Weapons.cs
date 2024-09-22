using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    public Transform arrowSocketPoint;
    public GameObject arrowPrefab;
    public float arrowSpeed = 20;
    public AudioClip arrowFireSound;

    private GameObject arrow;
    private float arrowLife = 3;

    public InputActionAsset playerController;
    InputAction fireButton;
    InputAction reloadButton;

    private void Start()
    {
        var gameActionButton = playerController.FindActionMap("XRI RightHand Interaction");
        fireButton = gameActionButton.FindAction("Activate");
        reloadButton = gameActionButton.FindAction("Select");

        fireButton.performed += fireArrow;
        fireButton.Enable();

        reloadButton.performed += reloadArrow;
        reloadButton.Enable();
    }

    public void reloadArrow(InputAction.CallbackContext context)
    {
        Debug.Log("reload");
        arrow = Instantiate(arrowPrefab, arrowSocketPoint.position, arrowSocketPoint.rotation, arrowSocketPoint);
        //arrow.transform.localPosition = Vector3.zero;
    }
    private void fireArrow(InputAction.CallbackContext context)
    {
        Debug.Log("fire");
        this.GetComponent<AudioSource>().PlayOneShot(arrowFireSound);
        arrowSocketPoint.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = arrowSocketPoint.forward * arrowSpeed;
        Destroy(arrowSocketPoint.GetChild(0).gameObject, arrowLife);
    }
}
