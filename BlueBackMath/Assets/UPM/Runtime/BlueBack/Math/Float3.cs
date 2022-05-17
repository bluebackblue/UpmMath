

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
	/** Float3
	*/
	#if(ASMDEF_TRUE)
	public static class Float3
	{
		/** CutEpsilon
		*/
		public static Unity.Mathematics.float3 CutEpsilon(in Unity.Mathematics.float3 a_value)
		{
			return new Unity.Mathematics.float3(
				((-0.0001f < a_value.x)&&(a_value.x < 0.0001f)) ? (0.0f) : (a_value.x),
				((-0.0001f < a_value.y)&&(a_value.y < 0.0001f)) ? (0.0f) : (a_value.y),
				((-0.0001f < a_value.z)&&(a_value.z < 0.0001f)) ? (0.0f) : (a_value.z)
			);
		}

		/** 内積。

			length(a_value_1) * length(a_value_2) * cos(theta)

		*/
		public static float Dot(in Unity.Mathematics.float3 a_value_1,in Unity.Mathematics.float3 a_value_2)
		{
			return a_value_1.x * a_value_2.x + a_value_1.y * a_value_2.y + a_value_1.z * a_value_2.z;
		}

		/** 外積。

			length(return) == length(a_value_1) * length(a_value_2) * abs(sin(theta))

		*/
		public static Unity.Mathematics.float3 Cross(in Unity.Mathematics.float3 a_value_1,in Unity.Mathematics.float3 a_value_2)
		{
			return a_value_1.yzx * a_value_2.zxy - a_value_1.zxy * a_value_2.yzx;
		}
	}
	#endif
}

