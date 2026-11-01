using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class UnitTwoWalker : MonoBehaviour
{
    [Min(0.1f)] public float moveSpeed = 4;
    [Min(0)] public float jumpHeight = 1.2f;
    [Range(0.01f,1)] public float mouseSensitivity = 0.12f;
    public Transform viewCamera;
    public Transform resetPoint;
    public float cameraDistance = 5;
    CharacterController controller;
    InputAction move, jump, look, orbit, restart;
    float verticalSpeed, yaw, pitch = 20;
    void Awake()
    {
        controller=GetComponent<CharacterController>();
        move=new InputAction("Move",InputActionType.Value);
        move.AddCompositeBinding("2DVector").With("Up","<Keyboard>/w").With("Down","<Keyboard>/s").With("Left","<Keyboard>/a").With("Right","<Keyboard>/d");
        jump=new InputAction("Jump",InputActionType.Button,"<Keyboard>/space");
        look=new InputAction("Look",InputActionType.Value,"<Mouse>/delta");
        orbit=new InputAction("Orbit",InputActionType.Button,"<Mouse>/rightButton");
        restart=new InputAction("Restart",InputActionType.Button,"<Keyboard>/r");
    }
    void OnEnable(){move.Enable();jump.Enable();look.Enable();orbit.Enable();restart.Enable();}
    void OnDisable(){move.Disable();jump.Disable();look.Disable();orbit.Disable();restart.Disable();}
    void OnDestroy(){move.Dispose();jump.Dispose();look.Dispose();orbit.Dispose();restart.Dispose();}
    void Update()
    {
        if(restart.WasPressedThisFrame()){SceneManager.LoadScene(SceneManager.GetActiveScene().name);return;}
        if(orbit.IsPressed()){
            Vector2 delta=look.ReadValue<Vector2>();
            yaw+=delta.x*mouseSensitivity;pitch=Mathf.Clamp(pitch-delta.y*mouseSensitivity,-10,65);
        }
        Vector2 input=Vector2.ClampMagnitude(move.ReadValue<Vector2>(),1);
        Vector3 direction=Quaternion.Euler(0,yaw,0)*new Vector3(input.x,0,input.y);
        if(controller.isGrounded && verticalSpeed<0)verticalSpeed=-2;
        if(controller.isGrounded && jump.WasPressedThisFrame())verticalSpeed=Mathf.Sqrt(jumpHeight*19.62f);
        verticalSpeed-=9.81f*Time.deltaTime;
        controller.Move((direction*moveSpeed+Vector3.up*verticalSpeed)*Time.deltaTime);
        if(direction.sqrMagnitude>0.01f)transform.rotation=Quaternion.LookRotation(direction);
        if(transform.position.y<-8 && resetPoint)Teleport(resetPoint);
    }
    void LateUpdate()
    {
        if(!viewCamera)return;
        Vector3 focus=transform.position+Vector3.up*0.7f;
        Vector3 offset=Quaternion.Euler(pitch,yaw,0)*Vector3.back*cameraDistance;
        // The player is on Ignore Raycast so this camera test only meets the environment.
        float distance=cameraDistance;
        if(Physics.SphereCast(focus,0.15f,offset.normalized,out RaycastHit hit,cameraDistance,Physics.DefaultRaycastLayers,QueryTriggerInteraction.Ignore))distance=Mathf.Max(0.2f,hit.distance-0.1f);
        viewCamera.position=focus+offset.normalized*distance;
        viewCamera.LookAt(focus);
    }
    public void Teleport(Transform destination)
    {
        if(!destination)return;
        controller.enabled=false;transform.position=destination.position;
        controller.enabled=true;verticalSpeed=0;
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var contact=hit.collider.GetComponent<UnitTwoContact>();
        if(contact)contact.Touch();
    }
}
