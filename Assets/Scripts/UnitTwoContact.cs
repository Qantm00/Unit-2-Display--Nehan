using UnityEngine;
using UnityEngine.Events;
public class UnitTwoContact : MonoBehaviour
{
    public UnityEvent onTouch = new UnityEvent();
    public bool once = true;
    bool used;
    public void Touch(){if(used && once)return;used=true;onTouch.Invoke();}
}
