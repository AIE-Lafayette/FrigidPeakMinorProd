using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetiAnimationBehaviour : MonoBehaviour
{

    private Animator _animation;
    // Update is called once per frame

    [SerializeField]
    private GameObject _snowball;


    SnowballMovementBehavior _snowballMovement;

    [SerializeField]
    private Transform _player;

    [SerializeField]
    private GameObject _leftHand;
    [SerializeField] 
    private GameObject _rightHand;

    private void Start()
    {
        _animation = GetComponent<Animator>();
        _snowballMovement = _snowball.GetComponent<SnowballMovementBehavior>();
        _leftHand.SetActive(false);
        _rightHand.SetActive(false);
    }

    void Update()
    {

        if (_player.position.x < transform.position.x)
        {
            _animation.SetBool("ThrowRight", false);
            _animation.SetBool("ThrowLeft", true);
            
        }

        else if (_player.position.x > transform.position.x)
        {
            _animation.SetBool("ThrowLeft", false);
            _animation.SetBool("ThrowRight", true);
        }
    }

    public void InstantiateSnowballsRightHand()
    {

        _snowballMovement.MovesRight = true;
        _snowballMovement.MovesLeft = false;

        Instantiate(_snowball, _rightHand.transform.position, _rightHand.transform.rotation); //Instantiate the snowballs
        _rightHand.SetActive(false);
    }

    public void SnowballInRightHand() { _leftHand.SetActive(true); }

    public void InstantiateSnowballsLeftHand()
    {
        _snowballMovement.MovesRight = false;
        _snowballMovement.MovesLeft = true;

        Instantiate(_snowball, _leftHand.transform.position, _leftHand.transform.rotation); //Instantiate the snowballs
        _leftHand.SetActive(false);
    }
    
    public void SnowballInLeftHand() { _rightHand.SetActive(true); }

    



}
