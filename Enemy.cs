using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector3[] _path;

    private void Start()
    {
        Tween tween = transform.DOPath(_path, 5, PathType.Linear);

        tween.SetLoops(-1, LoopType.Yoyo);
    }
}
