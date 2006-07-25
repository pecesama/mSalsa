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
	/// Wraps a presence message.
	/// </summary>
	public class XMLpresence
	{
		/// <summary>
		/// Contains a xml presence.
		/// </summary>
		public String presence;

		/// <summary>
		/// Initialize the presence variable.
		/// </summary>
		/// <param name="presence">Presence message.</param>
		public XMLpresence(string presence) 
		{
			this.presence=presence;
		}
	}
}
