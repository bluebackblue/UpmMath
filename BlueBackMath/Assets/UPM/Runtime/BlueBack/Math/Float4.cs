

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Math。
*/


/** BlueBack.Math
*/
namespace BlueBack.Math
{
	/** Float4
	*/
	public static class Float4
	{
		/** CutEpsilon
		*/
		public static Unity.Mathematics.float4 CutEpsilon(in Unity.Mathematics.float4 a_float4)
		{
			return new Unity.Mathematics.float4(
				((-0.0001f < a_float4.x)&&(a_float4.x < 0.0001f)) ? (0.0f) : (a_float4.x),
				((-0.0001f < a_float4.y)&&(a_float4.y < 0.0001f)) ? (0.0f) : (a_float4.y),
				((-0.0001f < a_float4.z)&&(a_float4.z < 0.0001f)) ? (0.0f) : (a_float4.z),
				((-0.0001f < a_float4.w)&&(a_float4.w < 0.0001f)) ? (0.0f) : (a_float4.w)
			);
		}
	}
}

