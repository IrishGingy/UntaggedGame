using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Reference: Custom scene transition effect in Unity by "Sunny Valley Studio" on Youtube
public class OpenEyesTransition : MonoBehaviour
{
    [SerializeField] Material screenTransitionMaterial;
    [SerializeField] float transitionTime = 1f;
    [SerializeField] string propertyName = "_Progress";
    [SerializeField] Image transitionImage;

    public UnityEvent OnTransitionDone;

    // Start is called before the first frame update
    void Start()
    {
        transitionImage.enabled = true;
        StartCoroutine(TransitionCoroutine());
    }

    private IEnumerator TransitionCoroutine()
    {
        float currentTime = 0;
        while(currentTime < transitionTime)
        {
            currentTime += Time.deltaTime;
            screenTransitionMaterial.SetFloat(propertyName, Mathf.Clamp(currentTime / transitionTime, 0, transitionTime));
            yield return null;
        }
        transitionImage.enabled = false;
        OnTransitionDone?.Invoke();
    }
}
