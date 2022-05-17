

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Math。
*/


/** define
*/
#if(ASMDEF_COM_UNITY_MATHEMATICS)
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.Math
*/
namespace BlueBack.Math
{
	/** Float4
	*/
	#if(ASMDEF_TRUE)
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
	#endif
}

