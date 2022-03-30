

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
		public static Unity.Mathematics.float4 CutEpsilon(in Unity.Mathematics.float4 a_value)
		{
			return new Unity.Mathematics.float4(
				((-0.0001f < a_value.x)&&(a_value.x < 0.0001f)) ? (0.0f) : (a_value.x),
				((-0.0001f < a_value.y)&&(a_value.y < 0.0001f)) ? (0.0f) : (a_value.y),
				((-0.0001f < a_value.z)&&(a_value.z < 0.0001f)) ? (0.0f) : (a_value.z),
				((-0.0001f < a_value.w)&&(a_value.w < 0.0001f)) ? (0.0f) : (a_value.w)
			);
		}
	}
}

