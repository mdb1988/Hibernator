using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hibernator.General
	{
				public class Watcher
				{
				private int _timeOut = 1;

				public void UpdateParams(int timeout)
				{
				_timeOut = timeout;
				 	Console.WriteLine("Current timeout: " +(_timeOut));
				}

				public void Print()
				{
				Console.WriteLine("Current timeout: " +(_timeOut * 60000) * 10);
				}

					public void Watch()
					{						
	 						Thread.Sleep(100000);						
								var idle = EnvironmentInfo.GetIdleTime();
								TimeSpan t = TimeSpan.FromMilliseconds(idle);
								string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",t.Hours,t.Minutes,t.Seconds);		
								Console.WriteLine(DateTime.Now + " - idle for " + answer);								
									if(idle > ((_timeOut * 60000)))
									{
										EnvironmentInfo.SetSuspendState(true,true,true);						
										Console.WriteLine("shutting down at " + DateTime.Now);
										
									}
				 }
				}
	}
