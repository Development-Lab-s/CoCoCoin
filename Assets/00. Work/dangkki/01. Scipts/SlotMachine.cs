using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class SlotMachene : MonoBehaviour
{
    public Button _button;
    private Rigidbody2D _rigid;
    private float _timer;
    [SerializeField] private Transform _spawn;
    public Transform[] _symbol;
    bool _isSpawn = false;
    int _spawnedIcon = 0;


    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _timer = 0;
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        _button.onClick.AddListener(ButtonClick);
        if (_timer > 1) {
            if (_isSpawn == true) {
                //Destroy(_symbol[_spawnedIcon]);
            }
            ButtonClick();
            _timer = 0;
            
        }
    }
    void ButtonClick()
    {
        _isSpawn = true;
        int range = Random.Range(0, 3);
        _spawnedIcon = range;
        Debug.Log(range);
        Instantiate(_symbol[range], _spawn);

    }

}
