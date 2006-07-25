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
	/// Input Class.
	/// </summary>
	public class Input
	{
		/// <summary>
		/// Received object.
		/// </summary>
		private Object Data;

		/// <summary>
		/// Data value.
		/// </summary>
		/// <value>The Data Object.</value>
		public Object data
		{
			get
			{
				return this.Data;
			}
			set
			{
				this.Data = value;
			}
		}

		/// <summary>
		/// Receives an object as input.
		/// </summary>
		/// <param name="data">input object.</param>
		public Input(Object data)
		{
			this.data = data;
		}
	}
}
