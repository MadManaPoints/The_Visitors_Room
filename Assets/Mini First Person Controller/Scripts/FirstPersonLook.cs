using UnityEngine;
using UnityEngine.UI;

public class FirstPersonLook : MonoBehaviour
{
    GameManager gm;
    AudioSource audio;
    [SerializeField] AudioClip ring;
    [SerializeField] AudioClip brokenBell;
    [SerializeField] AudioClip doors;
    [SerializeField] AudioClip openDoor;
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
    public bool bouquet;
    [SerializeField] GameObject flowers;

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
        //there's a script we got for audio but I'm too lazy to figure it out right now 
        audio = GetComponent<AudioSource>(); 

        if(gm.holdingFlowers){
            flowers.SetActive(true);
        } else {
            flowers.SetActive(false);
        }
    }

    void Update()
    {
        // Get smooth velocity.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 30);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

        Casting();

        if(gm.flowers > 9 && !bouquet){
            audio.PlayOneShot(openDoor, 0.7f);
            bouquet = true;
        }
    }

    void Casting(){

        //Cyclops!  
        Ray laser = Camera.main.ViewportPointToRay(centerScreen);
        RaycastHit hit = new RaycastHit();

        if(Physics.Raycast(laser, out hit)){
            //Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.tag == "Desk Bell" || hit.collider.tag == "Desk Fan" || hit.collider.tag == "Flower" || hit.collider.tag == "Door"){
                ret.color = Color.white;
            } else {
                ret.color = Color.grey;
            }

            //bell 
            if(hit.collider.tag == "Desk Bell" && Input.GetMouseButtonDown(0)){
                if(gm.bellPresses < 2){
                    audio.PlayOneShot(ring, 0.7f);
                } else if(gm.bellPresses == 2){
                    audio.PlayOneShot(brokenBell, 0.7f);
                    audio.PlayOneShot(doors, 0.7f);
                }
                rungBell = true;
                gm.bellPresses += 1;
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

            //door
            if(hit.collider.tag == "Door" && Input.GetMouseButtonDown(0)){
                audio.PlayOneShot(openDoor, 0.7f);

                if(gm.visits == 1 && hit.collider.gameObject.name == "Door 1"){
                    hit.transform.GetComponentInParent<OpenDoor>().doorOpen = true; 
                }

                if(gm.visits == 2 && hit.collider.gameObject.name == "Door 2"){
                    hit.transform.GetComponentInParent<OpenDoor>().doorOpen = true; 
                }

                if(gm.visits == 3 && hit.collider.gameObject.name == "Door 3"){
                    //hit.transform.GetComponentInParent<OpenDoor>().doorOpen = true;
                    gm.end = true;
                }

                if(hit.collider.gameObject.name == "Appear"){
                    hit.transform.GetComponentInParent<OpenDoor>().doorOpen = true;
                    GameObject.Find("Vanish").SetActive(false);
                }
                //hit.transform.GetComponentInParent<Transform>().localEulerAngles = hit.transform.GetComponentInParent<OpenDoor>().open;
            }

            if(hit.collider.tag == "Flower" && Input.GetMouseButtonDown(0)){
                if(gm.flowers < 10){
                    gm.flowers += 1; 
                    hit.transform.position = GameObject.Find("Holder").transform.position + new Vector3(Random.Range(-0.2f, 0.2f), 0, 0);
                    hit.transform.parent = GameObject.Find("Holder").transform;
                }
                
            }
        }

        //Debug.Log(rungBell);
    }
}
