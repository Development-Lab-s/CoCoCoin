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
    public Transform[] _spawn;
    public Transform[] _symbol;
    public GameObject basePrefab;
    public Sprite _sprite1;
    public Sprite _sprite2;
    public Sprite _sprite3;


    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _timer = 0; 
        _button.onClick.AddListener(ButtonClick);
    }
    private void Update()
    {
        //_timer += Time.deltaTime;
        //if (_timer > 1)
        //{
        //    if (_isSpawn == true)
        //    {
        //        //Destroy(_symbol[_spawnedIcon]);
        //    }
        //    ButtonClick();
        //    _timer = 0;

        //}
    }
    void ButtonClick()
    {
        //GameObject spawnedObj = Instantiate(basePrefab);
        //spawnedObj.GetComponent<SpriteRenderer>().sprite = _sprite1;
        //for (int i = 0; i < _spawn.Length; i++)
        //{
            foreach (Transform child in _spawn[0])
            {
                Destroy(child.gameObject);
            }
            int range = Random.Range(0, 3);
            Debug.Log(range);
            Instantiate(_symbol[range], _spawn[0]);

        //}
    }

}
