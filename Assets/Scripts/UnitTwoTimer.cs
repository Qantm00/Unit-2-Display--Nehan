using UnityEngine;
public class UnitTwoTimer : MonoBehaviour
{
    public GameObject target;
    [Min(0.1f)] public float interval = 2;
    float elapsed;
    void Update(){if(!target)return;elapsed+=Time.deltaTime;if(elapsed>=interval){elapsed-=interval;target.SetActive(!target.activeSelf);}}
}
