using System;
using UnityEngine;
using UnityEngine.Events;

public class SceneContext : MonoBehaviour
{
    [SerializeField]
    private ConfigProvider ConfigProvider;
    
    public EditorEvent OnPostResolve;
    
    [Serializable]
    public class EditorEvent : UnityEvent {}
    
    private void Start() //entry point, initialize all the 
    {
        //ConfigProvider.Reset();
        //ConfigProvider.OnEffectEnded = null;
        //ConfigProvider.OnEffectStarted = null;
    }
}
