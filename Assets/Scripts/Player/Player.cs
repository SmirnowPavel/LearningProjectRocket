using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public PlayerData rocket;

    public static Player Instance;
    PlayerLogic _playerLogic;
    [SerializeField]
    float _maxFuelLevel;
    [SerializeField]
    float _fuelLevel;

    [SerializeField]
    int _maxHp;
    [SerializeField]
    float _damageForce;
    [SerializeField]
    float _damageTime = 1f;
    int _hp = 0;

    public event Action onFuelLevelChanged = delegate { };
    public event Action onHpChange = delegate { };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AddDamageForce(collision.relativeVelocity.magnitude);
    }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _playerLogic = GetComponent<PlayerLogic>();
        _fuelLevel = _maxFuelLevel;
        _hp = _maxHp;
        //_hp = rocket.HP;
        //_damageForce = rocket.DamageForce;
        //_damageTime = rocket.DamageTime;
        //_fuelLevel = rocket.FuelLevel;


    }

    void Update()
    {
        CheckPosition();
    }

    void CheckPosition()
    {
        if (transform.position.y < -20)
            Kill();
    }

    public void Kill()
    {
        _hp = 0;
        Damage();
    }

    public void AddDamageForce(float val)
    {
        int time = 0;
        for (int i = 0; i < 4; i++)
        {
            if (val > _damageForce * i)
            {
                ++time;
            }

            if (time > 0)
            {
                Damage(time);
            }
        }
    }

    float lastHpDamaged = 0;

    public void Damage()
    {
        Damage(1);
    }

    public void Damage(int time)
    {
        if (Time.time - lastHpDamaged < _damageTime)
            return;

        lastHpDamaged = Time.time;
        _hp -= time;

        if (_hp <= 0)
        {
            //Scene of defeat
        }
    }

    public void WasteFuel(float how)
    {
        _fuelLevel -= how;
        onFuelLevelChanged();
    }

    public void AddFuel(float how)
    {
        rocket.AddFuel_(how);
        _fuelLevel = rocket.FuelLevel;
        onFuelLevelChanged();
    }

    public bool HasFuel()
    {
        return rocket.HasFuel_();
    }

    public int HPCount()
    {
        return Mathf.Max(_hp, 0);
    }

    public float FuelLevel01()
    {
        return _fuelLevel / _maxFuelLevel;
    }

}
