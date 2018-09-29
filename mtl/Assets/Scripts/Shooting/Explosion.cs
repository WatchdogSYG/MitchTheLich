using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Script : MonoBehaviour {

    public LayerMask m_UnitMask;
    public ParticleSystem m_ExplosionParticle;
    public AudioSource m_ExplosionAudio;
    public float m_MaxLifeTime = 2f;
    public float m_Damage = 100f;
    public float m_ExplosionForce = 1000f;
    public float m_ExplosionRadius = 5f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, m_MaxLifeTime);
	}

    // What happens when the fireball colides with something
    private void OnTriggerEnter(Collider other)
    {
        // Put all colliders in the explosion radius into an array
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_UnitMask);

        // Loop through the colliders to apply force and damages
        for (int i = 0; i < colliders.Length; i++)
        {
            // Find the Rigidbody for the collider in each iteration
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidbody)
            {
                continue;
            }
            // Apply the force
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            // Apply the damage here
            // colliders[i].GetComponent<HealthState>.(TakeDamage);
        }
        // Unparent the explosion
        m_ExplosionParticle.transform.parent = null;

        // Create the explosion
        m_ExplosionParticle.Play();

        // Play the explosion sound
        m_ExplosionAudio.Play();

        // Destroy the explosion when it is over
        var main = m_ExplosionParticle;
        Destroy(m_ExplosionParticle.gameObject, main.duration);

        // Destroy the fireball
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
