using UnityEngine;
public class UnitTwoResponse : MonoBehaviour
{
    public Renderer surface;
    public Color touchedColour = Color.green;
    public Transform door;
    public Vector3 doorOffset = new Vector3(0,3,0);
    bool opened;
    public void ChangeColour(){if(surface)surface.material.color=touchedColour;}
    public void OpenDoor(){if(!door || opened)return;opened=true;door.localPosition+=doorOffset;}
    public void Hide(){gameObject.SetActive(false);}
}
