using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject fire2;
    [SerializeField] private GameObject fire3;
    [SerializeField] private GameObject title;

    public void NotGoFire()
    {
        fire.SetActive(false);
        fire2.SetActive(false);
        fire3.SetActive(false);
    }
    public void GoFIre()
    {
        fire.SetActive(true);
        fire2.SetActive(true);
        fire3.SetActive(true);

    }
    public void UnTitle()
    {
        title.SetActive(false);
    }
    public void Title()
    {
        title.SetActive(true);
    }
}
