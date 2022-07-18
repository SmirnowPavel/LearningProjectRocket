using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour , IExpItem
{
    [SerializeField] private float m_DistanceExp = 1f;
    [SerializeField] private float m_ForceExp = 100f;
    //[SerializeField] private GameObject m_ParticleExp = null;
    [SerializeField] private float _destroyTime = 0.1f;
    [SerializeField] private float _detonateVelocity = 1f;
    [SerializeField] private float _destroyProbality = 0.2f;
    [SerializeField] private Sprite _crashSprite = null;
    private int m_Layer = 1 << 8;
    private bool _isDetonated = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > _detonateVelocity)
        {
            Boom();
        }
    }

    private IEnumerator Detonate()
    {
        yield return new WaitForSeconds(_destroyTime);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, m_DistanceExp, transform.up, m_DistanceExp, m_Layer);
        for (int i = 0; i < hits.Length; i++)
        {
            Rigidbody2D rigidbody = hits[i].collider.GetComponent<Rigidbody2D>();
            float distance = Vector3.Distance(hits[i].collider.transform.position, transform.position);
            if (rigidbody)
            {
                AddExplosionForce(rigidbody, m_ForceExp, transform.position, m_DistanceExp);
                IExpItem barrel = rigidbody.GetComponent<IExpItem>();
                Player player = rigidbody.GetComponent<Player>();
                if (barrel != null)
                {
                    barrel.Boom();
                }
                if (player)
                {
                    player.AddDamageForce(distance * m_ForceExp);
                }
            }

            bool destroed = Random.value < _destroyProbality;
            if (destroed)
            {
                Destroy(gameObject);
            }
            GetComponent<SpriteRenderer>().sprite = _crashSprite;
        }
    }

    public void Boom()
    {
        if(_isDetonated)
        {
            return;
            _isDetonated = true;
            StartCoroutine(Detonate());
        }
    }

    public void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        var diretion = body.transform.position - expPosition;
        float calc = 1 - (diretion.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }
        body.AddForce(diretion.normalized * expForce * calc);
    }
}

public interface IExpItem
{
    void Boom();
}
