using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] GameObject uiPanel;
    [SerializeField] TextMeshProUGUI _promptText;

    public bool isDisplayed = false;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        uiPanel.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var rotation = _mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void Close()
    {
        uiPanel.SetActive(false);
        isDisplayed = false;
    }

}
