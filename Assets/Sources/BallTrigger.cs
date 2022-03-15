using System;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem _pickUpParticles;

    private bool _isActive = true;

    public bool IsActive => _isActive;
    public static Action BallTriggered;

    private void OnTriggerEnter(Collider other)
    {
        _isActive = false;
        Instantiate(_pickUpParticles, transform.position, _pickUpParticles.transform.rotation);
        Destroy(gameObject);
        BallTriggered?.Invoke();
    }
}
