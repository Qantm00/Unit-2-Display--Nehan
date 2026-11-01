using UnityEngine;
public class UnitTwoMotion : MonoBehaviour
{
    public Vector3 travel = new Vector3(0,1,0);
    [Min(0.1f)] public float period = 3;
    public float degreesPerSecond = 60;
    public bool running = true;
    Vector3 start;float elapsed;
    void Awake(){start=transform.localPosition;}
    void Update(){if(!running)return;elapsed+=Time.deltaTime;transform.localPosition=start+travel*Mathf.Sin(elapsed/period*Mathf.PI*2);transform.Rotate(0,degreesPerSecond*Time.deltaTime,0,Space.Self);}
    public void SetRunning(bool value){running=value;}
}
