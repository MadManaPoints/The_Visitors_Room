using UnityEngine;
using UnityEngine.UI;

public class FirstPersonLook : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] AudioClip ring;
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;
    public bool rungBell;
    public bool fan = true; 
    Vector3 centerScreen = new Vector3(0.5f, 0.5f, 0f);
    [SerializeField] Image ret;


    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
        //there's a script we got for audio but I'm too lazy to figure it out right now 
        audio = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        // Get smooth velocity.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

        Casting();
    }

    void Casting(){

        //Cyclops!  
        Ray laser = Camera.main.ViewportPointToRay(centerScreen);
        RaycastHit hit = new RaycastHit();

        if(Physics.Raycast(laser, out hit)){
            //Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.tag == "Desk Bell" || hit.collider.tag == "Desk Fan"){
                ret.color = Color.white;
            } else {
                ret.color = Color.grey;
            }

            //bell 
            if(hit.collider.tag == "Desk Bell" && Input.GetMouseButtonDown(0)){
                audio.PlayOneShot(ring, 0.7f);
                rungBell = true;
            }

            if(rungBell && hit.collider.tag != "Desk Bell"){
                rungBell = false;
            }

            if(rungBell && Input.GetMouseButtonUp(0)){
                rungBell = false; 
            }

            //fan
            if(hit.collider.tag == "Desk Fan" && Input.GetMouseButtonDown(0)){
                fan = !fan;
            }
        }

        //Debug.Log(rungBell);
    }
}
