

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
	/** Quaternion
	*/
	#if(ASMDEF_TRUE)
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

		/** Inverse
		*/
		public static Unity.Mathematics.quaternion Inverse(in Unity.Mathematics.quaternion a_quaternion)
		{
			return new Unity.Mathematics.quaternion(-a_quaternion.value.x,-a_quaternion.value.y,-a_quaternion.value.z,a_quaternion.value.w);
		}

		/** AxisAngle
		*/
		public static Unity.Mathematics.quaternion AxisAngle(in Unity.Mathematics.float3 a_axis,float a_radian)
		{
			float t_sin_half_theta;
			float t_cos_half_theta;
			Unity.Mathematics.math.sincos(a_radian * 0.5f,out t_sin_half_theta,out t_cos_half_theta);

			return new Unity.Mathematics.quaternion(
				a_axis.x * t_sin_half_theta,
				a_axis.y * t_sin_half_theta,
				a_axis.z * t_sin_half_theta,
				t_cos_half_theta
			);
		}

		/** Normalize
		*/
		public static Unity.Mathematics.quaternion Normalize(in Unity.Mathematics.quaternion a_quaternion)
		{
			float t_length = Unity.Mathematics.math.length(a_quaternion.value);
			return new Unity.Mathematics.quaternion(a_quaternion.value / t_length);
		}

		/** Multiple
		*/
		public static Unity.Mathematics.quaternion Multiple(in Unity.Mathematics.quaternion a_quaternion_l,in Unity.Mathematics.quaternion a_quaternion_r)
		{
			return new Unity.Mathematics.quaternion(
				 a_quaternion_l.value.x * a_quaternion_r.value.w + a_quaternion_l.value.y * a_quaternion_r.value.z - a_quaternion_l.value.z * a_quaternion_r.value.y + a_quaternion_l.value.w * a_quaternion_r.value.x,
				-a_quaternion_l.value.x * a_quaternion_r.value.z + a_quaternion_l.value.y * a_quaternion_r.value.w + a_quaternion_l.value.z * a_quaternion_r.value.x + a_quaternion_l.value.w * a_quaternion_r.value.y,
				 a_quaternion_l.value.x * a_quaternion_r.value.y - a_quaternion_l.value.y * a_quaternion_r.value.x + a_quaternion_l.value.z * a_quaternion_r.value.w + a_quaternion_l.value.w * a_quaternion_r.value.z,
				-a_quaternion_l.value.x * a_quaternion_r.value.x - a_quaternion_l.value.y * a_quaternion_r.value.y - a_quaternion_l.value.z * a_quaternion_r.value.z + a_quaternion_l.value.w * a_quaternion_r.value.w
			);
		}

		/** Multiple
		*/
		public static Unity.Mathematics.float3 Multiple(in Unity.Mathematics.quaternion a_quaternion,in Unity.Mathematics.float3 a_point)
		{
			Unity.Mathematics.float3 t_temp = 2 * (a_quaternion.value.yzx * a_point.zxy - a_quaternion.value.zxy * a_point.yzx);
            return a_point + t_temp * a_quaternion.value.w + t_temp.zxy * a_quaternion.value.yzx - t_temp.yzx * a_quaternion.value.zxy;
		}

		/** LookRotationFast
		*/
		public static Unity.Mathematics.quaternion LookRotationFast(in Unity.Mathematics.float3 a_forward,in Unity.Mathematics.float3 a_up)
		{
			Unity.Mathematics.float3 t_up = Unity.Mathematics.math.normalize(a_up - (a_forward * Unity.Mathematics.math.dot(a_forward,a_up)));
			Unity.Mathematics.float3 t_right = Unity.Mathematics.math.cross(t_up,a_forward);

			float t_value = Unity.Mathematics.math.sqrt(t_right.x + t_up.y + a_forward.z + 1.0f) * 0.5f;
			float t_normalize = 0.25f / t_value;

			return new Unity.Mathematics.quaternion(
				(t_up.z - a_forward.y) * t_normalize,
				(a_forward.x - t_right.z) * t_normalize,
				(t_right.y - t_up.x) * t_normalize,
				t_normalize
			);
		}

		/** LookRotation
		*/
		public static Unity.Mathematics.quaternion LookRotation(in Unity.Mathematics.float3 a_forward,in Unity.Mathematics.float3 a_up)
		{
			Unity.Mathematics.float3 t_up = Unity.Mathematics.math.normalize(a_up - (a_forward * Unity.Mathematics.math.dot(a_forward,a_up)));
			Unity.Mathematics.float3 t_right = Unity.Mathematics.math.cross(t_up,a_forward);

			//Sqrtに渡してなるべく大きな値になるように。
			float t_value_0 =  t_right.x + t_up.y + a_forward.z + 1.0f;
			float t_value_1 = -t_right.x + t_up.y - a_forward.z + 1.0f;
			float t_value_2 =  t_right.x - t_up.y - a_forward.z + 1.0f;
			float t_value_3 = -t_right.x - t_up.y + a_forward.z + 1.0f;

			if((t_value_0 >= t_value_1)&&(t_value_0 >= t_value_2)&&(t_value_0 >= t_value_3)){
				//0
				float t_value = UnityEngine.Mathf.Sqrt(t_value_0) * 0.5f;
				float t_normalize = 0.25f / t_value;
				return new Unity.Mathematics.quaternion((t_up.z - a_forward.y) * t_normalize,(a_forward.x - t_right.z) * t_normalize,(t_right.y - t_up.x) * t_normalize,t_value);
			}else if((t_value_1 >= t_value_2)&&(t_value_1 >= t_value_3)){
				//1
				float t_value = UnityEngine.Mathf.Sqrt(t_value_1) * 0.5f;
				float t_normalize = 0.25f / t_value;
				return new Unity.Mathematics.quaternion((t_right.y + t_up.x) * t_normalize,t_value,(t_up.z + a_forward.y) * t_normalize,(a_forward.x - t_right.z) * t_normalize);
			}else if(t_value_2 >= t_value_3){
				//2
				float t_value = UnityEngine.Mathf.Sqrt(t_value_2) * 0.5f;
				float t_normalize = 0.25f / t_value;
				return new Unity.Mathematics.quaternion(t_value,(t_right.y + t_up.x) * t_normalize,(a_forward.x + t_right.z) * t_normalize,(t_up.z - a_forward.y) * t_normalize);
			}else{
				//3
				float t_value = UnityEngine.Mathf.Sqrt(t_value_3) * 0.5f;
				float t_normalize = 0.25f / t_value;
				return new Unity.Mathematics.quaternion((a_forward.x + t_right.z) * t_normalize,(t_up.z + a_forward.y) * t_normalize,t_value,(t_right.y - t_up.x) * t_normalize);
			}
		}

		/** LookRotation_Mathematics

			https://github.com/Unity-Technologies/Unity.Mathematics/blob/master/src/Unity.Mathematics/quaternion.cs#L390

		*/
		public static Unity.Mathematics.quaternion LookRotation_Mathematics(in Unity.Mathematics.float3 a_forward,in Unity.Mathematics.float3 a_up)
		{
            Unity.Mathematics.float3 t_right = Unity.Mathematics.math.normalize(Unity.Mathematics.math.cross(a_up,a_forward));
            return Create_Mathematics(in t_right,Unity.Mathematics.math.cross(a_forward,t_right),in a_forward);
		}

		/** Create_Mathematics

			https://github.com/Unity-Technologies/Unity.Mathematics/blob/master/src/Unity.Mathematics/quaternion.cs#L44

		*/
		public static Unity.Mathematics.quaternion Create_Mathematics(in Unity.Mathematics.float3 a_right,in Unity.Mathematics.float3 a_up,in Unity.Mathematics.float3 a_forward)
		{
			uint t_right_sign = (Unity.Mathematics.math.asuint(a_right.x) & 0x80000000);
			float t_value = a_up.y + Unity.Mathematics.math.asfloat(Unity.Mathematics.math.asuint(a_forward.z) ^ t_right_sign);
			Unity.Mathematics.uint4 t_right_mask = Unity.Mathematics.math.uint4((int)t_right_sign >> 31);
			Unity.Mathematics.uint4 t_value_mask = Unity.Mathematics.math.uint4(Unity.Mathematics.math.asint(t_value) >> 31);
			Unity.Mathematics.uint4 t_sign_flips = Unity.Mathematics.math.uint4(0x00000000,0x80000000,0x80000000,0x80000000) ^ (t_right_mask & Unity.Mathematics.math.uint4(0x00000000,0x80000000,0x00000000,0x80000000)) ^ (t_value_mask & Unity.Mathematics.math.uint4(0x80000000,0x80000000,0x80000000,0x00000000));

			Unity.Mathematics.quaternion t_quaternion;
			{
				t_quaternion.value = Unity.Mathematics.math.float4(1.0f + Unity.Mathematics.math.abs(a_right.x),a_right.y,a_forward.x,a_up.z) + Unity.Mathematics.math.asfloat(Unity.Mathematics.math.asuint(Unity.Mathematics.math.float4(t_value,a_up.x,a_right.z,a_forward.y)) ^ t_sign_flips);
				t_quaternion.value = Unity.Mathematics.math.asfloat((Unity.Mathematics.math.asuint(t_quaternion.value) & ~t_right_mask) | (Unity.Mathematics.math.asuint(t_quaternion.value.zwxy) & t_right_mask));
				t_quaternion.value = Unity.Mathematics.math.asfloat((Unity.Mathematics.math.asuint(t_quaternion.value.wzyx) & ~t_value_mask) | (Unity.Mathematics.math.asuint(t_quaternion.value) & t_value_mask));
				t_quaternion.value = Unity.Mathematics.math.normalize(t_quaternion.value);
			}
			return t_quaternion;
		}
	}
	#endif
}

