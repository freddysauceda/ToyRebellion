using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AiActionType { Nothing, Move, Attack, Capture };

[System.Serializable]
public struct AiAction {

    public AiActionType order;
    public Transform target;
    public Vector3 targetPosition;
}
