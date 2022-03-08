

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Math。
*/


/** BlueBack.Math
*/
namespace BlueBack.Math
{
	/** Quaternion
	*/
	public static class Quaternion
	{
		/** Dot
		*/
		public static float Dot(in Unity.Mathematics.quaternion a_quaternion_l,in Unity.Mathematics.quaternion a_quaternion_r)
		{
			return (
				a_quaternion_l.value.x * a_quaternion_r.value.x + 
				a_quaternion_l.value.y * a_quaternion_r.value.y + 
				a_quaternion_l.value.z * a_quaternion_r.value.z + 
				a_quaternion_l.value.w * a_quaternion_r.value.w
			);
		}
	}
}

