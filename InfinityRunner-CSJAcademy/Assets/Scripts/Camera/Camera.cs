using UnityEngine;

public class Camera : MonoBehaviour
{
    #region Properties

    private Transform _player;
    [SerializeField] private float _speedFollowCam;
    [SerializeField] private float _offSet;

    #endregion

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Logic.UpdateFollow(_player, transform, _speedFollowCam, _offSet);
    }
}
