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
	/// Reasoning component of the Agent.
	/// </summary>
	public abstract class Reasoning
	{
		/// <summary>
		/// Acting component
		/// </summary>
		public Acting acting;

		/// <summary>
		/// Create the instance  of the reasoning component.
		/// </summary>
		public Reasoning() { }					
		
		/// <summary>
		/// Overwrite this method to specify the reasoning algorithm.
		/// </summary>
		/// <param name="ev">Event generated in the perception component which invoks the think method</param>
		/// <param name="xml">The XML Jabber message.</param>
		public abstract void think(salsa_event_type ev, string xml);


		/// <summary>
		/// Set the Acting component.
		/// </summary>
		/// <param name="acting">The Acting component.</param>
		public void setActing(Acting acting)
		{
			this.acting=acting;
		}
	}
}
