using UnityEngine;

public class SlotCheck : MonoBehaviour
{
    public GameObject slotMachine1;
    public GameObject slotMachine2;
    public GameObject slotMachine3;
    private void Awake()
    {
        slotMachine1 = GetComponent<GameObject>();
        slotMachine2 = GetComponent<GameObject>();
        slotMachine3 = GetComponent<GameObject>();
    }
    private void Update()
    {
        //slotMachine3.GetComponentsInChildren<
    }
}
