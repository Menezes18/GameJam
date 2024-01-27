using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // Objeto de referência a ser seguido
    public float speed = 5f; // Velocidade de movimento do objeto

    void Update()
    {
        if (target != null)
        {
            // Calcula a direção para o objeto de referência
            Vector3 direction = target.position - transform.position;

            // Normaliza a direção para manter uma velocidade constante
            direction.Normalize();

            // Move o objeto na direção do objeto de referência
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}