﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hibernator.General
	{
	public class EnvironmentInfo
		{
		[DllImport("Powrprof.dll",CharSet = CharSet.Auto,ExactSpelling = true)]
		public static extern bool SetSuspendState(bool hiberate,bool forceCritical,bool disableWakeEvent);

		[DllImport("User32.dll")]
		private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

		[DllImport("Kernel32.dll")]
		private static extern uint GetLastError();

		public static uint GetIdleTime()
			{
			LASTINPUTINFO lastInPut = new LASTINPUTINFO();
			lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
			GetLastInputInfo(ref lastInPut);
			return ((uint)Environment.TickCount - lastInPut.dwTime);
			}

		public static long GetLastInputTime()
			{
			LASTINPUTINFO lastInPut = new LASTINPUTINFO();
			lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);

			if(!GetLastInputInfo(ref lastInPut))
				{
				throw new Exception(GetLastError().ToString());
				}

			return lastInPut.dwTime;
			}

		internal struct LASTINPUTINFO
			{
			public uint cbSize;

			public uint dwTime;
			}
		}
	}
