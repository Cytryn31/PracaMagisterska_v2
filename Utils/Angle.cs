/*
 * Created by: Milton García Borroto (milton.garcia@gmail.com),
 *             Miguel Angel Medina Pérez (miguel.medina.perez@gmail.com), and
 *             Andrés Eduardo Gutiérrez Rodríguez (andres@bioplantas.cu)
 * Created: 
 * Comments by: Miguel Angel Medina Pérez (miguel.medina.perez@gmail.com)
 */

using System;

namespace PracaMagisterska_v2.Utils
{
	/// <summary>
	///     Provides basic functionality related to angles.
	/// </summary>
	public static class Angle
	{
		/// <summary>
		///     Computes the angle formed by the specified horizontal and vertical variations.
		/// </summary>
		/// <param name="dX">The horizontal variation.</param>
		/// <param name="dY">The vertical variation.</param>
		/// <returns>
		///     The angle in radians formed by the specified horizontal and vertical variations.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     Thrown when <paramref name="dX"/>==0 and <paramref name="dY"/>==0 because no angle can be computed.
		/// </exception>
		public static double ComputeAngle(double dX, double dY)
		{
			if (dX > 0 && dY >= 0)
				return Math.Atan(dY / dX);
			if (dX > 0 && dY < 0)
				return Math.Atan(dY / dX) + 2 * Math.PI;
			if (dX < 0)
				return Math.Atan(dY / dX) + Math.PI;
			if (dX == 0 && dY > 0)
				return Math.PI / 2;
			if (dX == 0 && dY < 0)
				return 3 * Math.PI / 2;
			throw new ArgumentOutOfRangeException();
		}

		/// <summary>
		///     Computes the angle required to rotate one vector with angle <paramref name="alpha"/> in counterclockwise sense to superpose it to another vector with the same origin and angle <paramref name="beta"/>.
		/// </summary>
		/// <remarks>
		///     This function returns the angle in radians and it is defined in the interval [0,π). This is not a symmetric function, so it returns different values when swapping parameters.  
		/// </remarks>
		/// <param name="alpha">
		///     The angle, in radians, of the vector that is rotated in counterclockwise sense.
		/// </param>
		/// <param name="beta">
		///     The angle, in radians, of the vector that is not rotated.
		/// </param>
		/// <returns>
		///     The computed angle in radians.
		/// </returns>
		public static double Difference2Pi(double alpha, double beta)
		{
			if (beta >= alpha)
				return (beta - alpha);
			return beta - alpha + 2 * Math.PI;
		}

		/// <summary>
		///     Computes the minimum rotation angle required to superpose two vectors with the same origin and the specified angles.
		/// </summary>
		/// <remarks>
		///     This function returns the angle in radians and it is defined in the interval [0,π). This is a symmetric function, so it returns the same value when swapping parameters.
		/// </remarks>
		/// <param name="alpha">
		///     The angle of one vector.
		/// </param>
		/// <param name="beta">
		///     The angle of the other vector.
		/// </param>
		/// <returns>
		///     The computed angle in radians.
		/// </returns>
		public static double DifferencePi(double alpha, double beta)
		{
			double diff = Math.Abs(beta - alpha);
			return Math.Min(diff, 2 * Math.PI - diff);
		}

		/// <summary>
		///     Computes the minimum rotation angle required to superpose two vectors with the same origin and the specified angles.
		/// </summary>
		/// <remarks>
		///     This function returns the angle in degrees and it is defined in the interval [0,180º). This is a symmetric function, so it returns the same value when swapping parameters.
		/// </remarks>
		/// <param name="alpha">
		///     The angle in degrees of one vector.
		/// </param>
		/// <param name="beta">
		///     The angle in degrees of the other vector.
		/// </param>
		/// <returns>
		///     The computed angle in degrees.
		/// </returns>
		public static int Difference180(int alpha, int beta)
		{
			int diff = Math.Abs(beta - alpha);
			return Math.Min(diff, 360 - diff);
		}

		/// <summary>
		///     Converts the specified degrees into radians.
		/// </summary>
		/// <param name="degrees">The degrees to convert into radians.</param>
		/// <returns>
		///     The radians computed from the specified degrees.
		/// </returns>
		public static double ToRadians(int degrees)
		{
			return degrees * Math.PI / 180;
		}

		/// <summary>
		///     Converts the specified radians into degrees.
		/// </summary>
		/// <param name="radians">The radians to convert into degrees.</param>
		/// <returns>
		///     The degrees computed from the specified radians.
		/// </returns>
		public static double ToDegrees(double radians)
		{
			return radians * 180 / Math.PI;
		}
	}
}
