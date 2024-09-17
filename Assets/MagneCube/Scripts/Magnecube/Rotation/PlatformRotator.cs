using System.Collections;
using UnityEngine;
using DG.Tweening;


public class PlatformRotator : MonoBehaviour
{
    [SerializeField] private int _rotationAngle = 90;
    [SerializeField] private float _rotationDuration = 1f;
    [SerializeField] private float _waitTimeBetweenRotations = 1.5f;
    [SerializeField] private Ease _ease = Ease.InQuint;

    private bool _isPlayerOnPlatform = false;
    private bool _isRotating = false;
    private Character _character;

    private void OnValidate()
    {
        _rotationAngle = Mathf.RoundToInt(_rotationAngle / 90f) * 90;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out _character))
        {
            _isPlayerOnPlatform = true;
            if (!_isRotating)
            {
                _character.StartMoving += CharacterDettach;
                StartCoroutine(WaitBetweenRotations());
            }
        }
    }

    public void CharacterDettach() {
        _isPlayerOnPlatform = false;
        StopAllCoroutines();
        _character.StartMoving -= CharacterDettach;
        _character = null;
    }

    private IEnumerator WaitBetweenRotations()
    {
        yield return new WaitForSeconds(_waitTimeBetweenRotations);
        if (_isPlayerOnPlatform)
        {
            StartRotation();
        }
    }
    public void StartRotation()
    {
        _character.DisallowMovement();
        _isRotating = true;
        RotatePlatform();
    }
    private void RotatePlatform()
    {
        transform.DORotate(new Vector3(0,0,_rotationAngle), _rotationDuration, RotateMode.LocalAxisAdd)
                     .SetEase(_ease).OnComplete(EndRotation);
    }

    private void EndRotation()
    {
        _isRotating = false;
        _character.AlignCheckers(-_rotationAngle);
        _character.AllowMovement();
        StartCoroutine(WaitBetweenRotations());
    }
}