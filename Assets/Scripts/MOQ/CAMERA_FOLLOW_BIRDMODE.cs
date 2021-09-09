using System.Collections.Generic;
using UnityEngine;

public class CAMERA_FOLLOW_BIRDMODE : MonoBehaviour
{
    [SerializeField] private List<Vector3> _listOfPositions;
    [SerializeField] private byte _currentPositionInList = 0;
    [SerializeField] private Transform _carTranform;
    [SerializeField, Range(-20f, 20f)] private float _offset;

    void Start()
    {
        _carTranform = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ChangeCameraPos();
        }
    }
    void FixedUpdate()
    {
        this.gameObject.transform.LookAt(_carTranform);
        this.gameObject.transform.position = new Vector3(_listOfPositions[_currentPositionInList].x, _listOfPositions[_currentPositionInList].y, _carTranform.position.z + _offset);
    }

    private void ChangeCameraPos()
    {
        if (_currentPositionInList != _listOfPositions.Count - 1)
        {
            _currentPositionInList++;
        }
        else
            _currentPositionInList = 0;
    }
}
