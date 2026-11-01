using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider))]
public class UnitTwoTrigger : MonoBehaviour
{
    public UnityEvent onEnter = new UnityEvent();
    public UnityEvent onExit = new UnityEvent();
    public Transform teleportTo;
    void OnTriggerEnter(Collider other)
    {
        var walker=other.GetComponent<UnitTwoWalker>();if(!walker)return;
        onEnter.Invoke();if(teleportTo)walker.Teleport(teleportTo);
    }
    void OnTriggerExit(Collider other){if(other.GetComponent<UnitTwoWalker>())onExit.Invoke();}
}
