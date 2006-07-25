//=-------
// Copyright 2005, Pedro Santana
// 
//   Provided as is, with no warrenty, etc.
//   License is granted to use, copy, modify, 
//   with or without credit to me, just don't
//   blame me if it doesn't work.
//=-------

using System;

namespace mSalsa
{
	/// <summary>
	/// Wraps an xml message.
	/// </summary>
	public class XMLmessage
	{		
		/// <summary>
		/// Contains a xml message.
		/// </summary>
		public String msg;

		/// <summary>
		/// Initialize the msg variable.
		/// </summary>
		/// <param name="msg">An xml message.</param>
		public XMLmessage(string msg) 
		{
			this.msg=msg;
		}
	}
}
