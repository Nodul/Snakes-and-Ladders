using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCameraOnBoard : MonoBehaviour
{
    private Camera _cam;
    private BoardRenderer _boardRenderer;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
        _boardRenderer = FindObjectOfType<BoardRenderer>();
    }

    void Start()
    {
        CenterCamOnBoard();
    }

    private void CenterCamOnBoard() 
    {
        _cam.transform.position = new Vector3(_boardRenderer.BoardSizeLength / 2, _boardRenderer.BoardSizeLength / 2, _cam.transform.position.z);
    }
}
