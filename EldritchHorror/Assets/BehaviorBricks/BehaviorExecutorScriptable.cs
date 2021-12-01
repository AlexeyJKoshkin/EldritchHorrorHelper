using BBUnity;
using Pada1.BBCore;
using System;
using UnityEngine;

[CreateAssetMenu]
public class BehaviorExecutorScriptable : ScriptableObject
{
    [SerializeField]
    private GameObject _gameObjectView;
    [Range(1f, 1000f)]
    public int maxTasksPerTick = 500;
    public UnityBlackboard blackboard = new UnityBlackboard();
    public InternalBrickAsset behavior;
    public bool paused;
    public bool restartWhenFinished;
    [HideInInspector]
    [NonSerialized]
    public bool requestTickExecution;
    private bool debugMode;
    private BrickExecutor worker;

    protected void setDebugMode()
    {
        this.debugMode = true;
    }

    public virtual void Init()
    {
#if UNITY_EDITOR
        setDebugMode();
    
#endif
        if ((UnityEngine.Object) this.behavior == (UnityEngine.Object) null)
        {
            this.worker = (BrickExecutor) null;
            Debug.LogWarning((object) "BehaviorExecutor without behavior. Check the object inspector");
        }
        else
        {
            if (this.behavior.behavior != null)
                this.blackboard.updateParams(this.behavior.behavior.inParamValues);
            this.worker = new BrickExecutor(_gameObjectView, (Blackboard) null);
            if (this.debugMode)
                this.worker.ActivateDebugMode();
            this.StartBehavior();
        }
    }

    public ExecutorDebugger GetDebugger()
    {
        return this.debugMode && this.worker != null ? this.worker.GetDebugger() : (ExecutorDebugger) null;
    }

    public void TickUpdate()
    {
#if UNITY_EDITOR
        bool prev = this.requestTickExecution;
#endif
        DoTick();
#if UNITY_EDITOR
        if (prev != this.requestTickExecution)
            // Force inspector repaint in editor mode to reactivate
            // Tick button.
            UnityEditor.EditorUtility.SetDirty(this);
#endif
    }

    private void DoTick()
    {
        if (this.worker == null || this.paused && !this.requestTickExecution)
            return;
        if (!this.worker.Finished)
            this.worker.Tick(this.maxTasksPerTick);
        if (this.worker.Finished && this.restartWhenFinished)
            this.StartBehavior();
        if (!this.requestTickExecution)
            return;
        this.requestTickExecution = false;
    }

    private void StartBehavior()
    {
        this.behavior.RegisterSubbehaviors();
        this.worker.SetBrickAsset(this.behavior, this.blackboard.BuildBlackboard());
    }

    public void OnValidate()
    {
        if ((UnityEngine.Object) this.behavior != (UnityEngine.Object) null && this.behavior.behavior != null)
            this.blackboard.updateParams(this.behavior.behavior.inParamValues);
        else
            this.blackboard.updateParams((InParamValues) null);
    }

    public bool SetBehaviorParam(string paramName, object value)
    {
        return this.blackboard.SetBehaviorParam(paramName, value);
    }



}