

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Math。
*/


/** BlueBack.Math
*/
namespace BlueBack.Math
{
	/** Float3
	*/
	public static class Float3
	{
		/** CutEpsilon
		*/
		public static Unity.Mathematics.float3 CutEpsilon(in Unity.Mathematics.float3 a_float3)
		{
			return new Unity.Mathematics.float3(
				((-0.0001f < a_float3.x)&&(a_float3.x < 0.0001f)) ? (0.0f) : (a_float3.x),
				((-0.0001f < a_float3.y)&&(a_float3.y < 0.0001f)) ? (0.0f) : (a_float3.y),
				((-0.0001f < a_float3.z)&&(a_float3.z < 0.0001f)) ? (0.0f) : (a_float3.z)
			);
		}
	}
}

