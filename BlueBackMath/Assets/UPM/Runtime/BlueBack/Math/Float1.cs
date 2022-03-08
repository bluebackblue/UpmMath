

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Math。
*/


/** BlueBack.Math
*/
namespace BlueBack.Math
{
	/** Float1
	*/
	public static class Float1
	{
		/** CutEpsilon
		*/
		public static float CutEpsilon(float a_float1)
		{
			return ((-0.0001f < a_float1)&&(a_float1 < 0.0001f)) ? (0.0f) : (a_float1);
		}
	}
}

