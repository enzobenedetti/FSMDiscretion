using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedBoost = 2f;
    [SerializeField] private float sneakingSpeed = 0.5f;

    private Vector3 _startSpawn;
    private Quaternion _spawnRotation;

    private void Awake()
    {
        _startSpawn = transform.position;
        _spawnRotation = transform.rotation;
    }

    void Update()
    {
        if (GameStatus.GameState == GameStatus.GameStateEnum.InGame)
            Move();
        if (GameStatus.GameState == GameStatus.GameStateEnum.Home)
        {
            transform.position = _startSpawn;
            transform.rotation = _spawnRotation;
        }
    }

    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            float move = Input.GetButton("Sneak") == true ? Input.GetAxis("Horizontal") * Time.deltaTime * sneakingSpeed : Input.GetAxis("Horizontal") * Time.deltaTime * speedBoost;
            this.transform.position += new Vector3(move, 0, 0);
        }
        if (Input.GetButton("Vertical"))
        {
            float move = Input.GetButton("Sneak") == true ? Input.GetAxis("Vertical") * Time.deltaTime * sneakingSpeed : Input.GetAxis("Vertical") * Time.deltaTime * speedBoost;
            this.transform.position += new Vector3(0, 0, move);
        }
    }
}
