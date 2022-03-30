

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
		public static float CutEpsilon(float a_value)
		{
			return ((-0.0001f < a_value)&&(a_value < 0.0001f)) ? (0.0f) : (a_value);
		}
	}
}

