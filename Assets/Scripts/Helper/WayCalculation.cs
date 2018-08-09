using UnityEngine;

namespace Helper
{
    public static class WayCalculation
    {

        /// <summary>
        /// This method calculates if there is any way  left between two given Vectors on the Y-Axis
        /// </summary>
        /// <param name="_actualPosition"></param>
        /// <param name="_destination"></param>
        /// <returns></returns>
        public static bool CalculateWayLeftY(Vector3 _actualPosition, Vector3 _destination)
        {
            return (Mathf.Abs((_actualPosition.y - _destination.y)) <= 0.1f) ? false : true;
        }

        /// <summary>
        /// This method calculates if there is any way  left between two given Vectors on the X-Axis
        /// </summary>
        /// <param name="_actualPosition"></param>
        /// <param name="_destination"></param>
        /// <returns></returns>
        public static bool CalculateWayLeftX(Vector3 _actualPosition, Vector3 _destination)
        {
            return (Mathf.Abs((_actualPosition.x - _destination.x)) <= 0.1f) ? false : true;
        }
    }

}
