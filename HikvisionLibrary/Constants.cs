using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikvisionLibrary
{
	/// <summary>
	/// Константы
	/// </summary>
	public static class Constants
	{
		/// <summary>
		/// Максимальная длина серийного номера структуры DeviceInfo
		/// </summary>
		public const int SERIALNO_LEN = 48;
		/// <summary>
		/// Максимальная длина идентификатора потока для структуры PreviewInfo.
		/// </summary>
		public const int STREAM_ID_LEN = 32;
	}
}
