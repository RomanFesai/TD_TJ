using UnityEngine;

namespace Assets.Scripts
{
    public static class Utilities
    {
        public static Vector3 Set(this Vector3 v, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? v.x, y ?? v.y, z ?? v.z);
        }
    }
}