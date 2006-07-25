//=-------
// Copyright 2005, Pedro Santana
// 
//   Provided as is, with no warrenty, etc.
//   License is granted to use, copy, modify, 
//   with or without credit to me, just don't
//   blame me if it doesn't work.
//=-------

using System;

using agsXMPP;

namespace mSalsa
{
	/// <summary>
	/// Acting component of the Agent.
	/// </summary>
	public class Acting
	{

		/// <summary>
		/// Jabber Client instance.
		/// </summary>
		private JabberClient jc;

		/// <summary>
		/// Recive the Jabber Client to use it in Action Class
		/// </summary>
		/// <param name="jClient">Jabber Client Instance</param>
		public Acting(JabberClient jClient)
		{
			this.jc=jClient;
		}
		
		/// <summary>
		/// Execute an action
		/// </summary>
		/// <param name="action">Action Class Instance</param>
		public void act(Action action)
		{		
			action.setProxyBroker(this.jc);
			action.execute();
		}
	}
}
