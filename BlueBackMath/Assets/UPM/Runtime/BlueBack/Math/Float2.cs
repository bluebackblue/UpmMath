

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Math。
*/


/** BlueBack.Math
*/
namespace BlueBack.Math
{
	/** Float2
	*/
	public static class Float2
	{
		/** CutEpsilon
		*/
		public static Unity.Mathematics.float2 CutEpsilon(in Unity.Mathematics.float2 a_float2)
		{
			return new Unity.Mathematics.float2(
				((-0.0001f < a_float2.x)&&(a_float2.x < 0.0001f)) ? (0.0f) : (a_float2.x),
				((-0.0001f < a_float2.y)&&(a_float2.y < 0.0001f)) ? (0.0f) : (a_float2.y)
			);
		}
	}
}

