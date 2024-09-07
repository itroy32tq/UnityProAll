using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class MouseRotateInput : MonoBehaviour
    {
    

        private void Update()
        {

            //плоскость игры
            Plane plane = new(Vector3.up, Vector3.zero);

            //луч в сторону курсора мыши
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //вот она радимая точка курсора в мировых координатах
            Vector3? intersection = GetIntersection(plane, ray);

            if (intersection.HasValue)
            {
                transform.position = intersection.Value;
            }
        }


        public Vector3? GetIntersection(Plane plane, Ray ray)
        {
            bool success = plane.Raycast(ray, out float distance);

            if (success)
            {
                return ray.GetPoint(distance);
            }
            return null;
        }
    }
}
