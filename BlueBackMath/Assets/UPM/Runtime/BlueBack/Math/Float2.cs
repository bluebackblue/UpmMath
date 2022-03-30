

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
		public static Unity.Mathematics.float2 CutEpsilon(in Unity.Mathematics.float2 a_value)
		{
			return new Unity.Mathematics.float2(
				((-0.0001f < a_value.x)&&(a_value.x < 0.0001f)) ? (0.0f) : (a_value.x),
				((-0.0001f < a_value.y)&&(a_value.y < 0.0001f)) ? (0.0f) : (a_value.y)
			);
		}
	}
}

