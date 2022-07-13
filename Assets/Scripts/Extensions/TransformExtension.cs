/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public static class TransformExtension
{
    public static void LookAt(this Transform transform, Vector3 target, float angularSpeed)
    {
        Vector3 lookPos = target - transform.position;
        lookPos.y = 0;

        Quaternion rotation = Quaternion.LookRotation(lookPos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, angularSpeed);
    }
}
