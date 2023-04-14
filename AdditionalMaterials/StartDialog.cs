using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartDialog : MonoBehaviour
{

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject ActivateGPT;
    [SerializeField] private GameObject standingPoint;

    private Transform mainCharacter;
    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainCharacter = other.transform;

            // disable player input

            mainCharacter.GetComponent<PlayerInput>().enabled = false;

            await Task.Delay(50);


            // teleport mainCharacter to standingPoint
            mainCharacter.position = standingPoint.transform.position;
            mainCharacter.rotation = standingPoint.transform.rotation;


            // disable main camera, enable dialog camera
            mainCamera.SetActive(false);
            ActivateGPT.SetActive(true);


            // display cursor

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Recover()
    {
        

        mainCharacter.GetComponent<PlayerInput>().enabled = true;
        mainCamera.SetActive(true);
        ActivateGPT.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
