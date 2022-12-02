using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{

    [SerializeField] GameObject m_Particles;
    [SerializeField] float m_LifeTime = 2.0f;

    public void EmitParticlesOnHit(Transform transform)
    {
        if (m_Particles == null)
            return;

        GameObject particles = Instantiate(m_Particles, transform.position, transform.rotation);
        particles.transform.SetParent(this.gameObject.transform);
        Destroy(particles, m_LifeTime);
    }
}
