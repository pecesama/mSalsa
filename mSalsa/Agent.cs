//=-------
// Copyright 2005, Pedro Santana
// 
//   Provided as is, with no warrenty, etc.
//   License is granted to use, copy, modify, 
//   with or without credit to me, just don't
//   blame me if it doesn't work.
//=-------

using System;
using System.Diagnostics;

using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.protocol.iq;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.agent;
using agsXMPP.Xml.DomParser;

using System.Threading;

namespace mSalsa
{
	/// <summary>
	/// mSalsa Agent Class
	/// </summary>
	public class Agent
	{

		/// <summary>
		/// Jabber Client instance.
		/// </summary>
		private JabberClient jc;
		/// <summary>
		/// Acting instance.
		/// </summary>
		private Acting acting;
		/// <summary>
		/// Reasoning instance.
		/// </summary>
		private Reasoning reasoning;
		/// <summary>
		/// Passive Perception instance.
		/// </summary>
		public PassivePerception passivePerception;

		/// <summary>
		/// Create an Agent instance.
		/// </summary>
		public Agent() {}


		/// <summary>
		/// Create and activate an agent that communicates through instant messaging with other agents
		/// </summary>
		/// <param name="rsn">Reasoning Class Instance</param>
		/// <param name="jClient">Jabber Client Instance</param>
		protected void activate(Reasoning rsn, JabberClient jClient)
		{
			try
			{
				//Se especifica el cliente jabber para este agente
				this.setProxyBroker(jClient);

				//Creando componentes del agente
				create(rsn);

				jc.setReasoning(rsn);

				//Se conecta el cliente jabber				
				jc.Open();

				/*DEBUG*/
				//Debug.WriteLine("->Agent.activate():Active Agent");				
			} 
			catch (Exception ex)
			{ 
				Debug.WriteLine(ex.ToString());	
			}
		}

		/// <summary>
		/// This method make an instance of the Jabber Client for Class Action.
		/// </summary>
		/// <param name="jClient">Jabber Client Instance</param>
		private void setProxyBroker(JabberClient jClient)
		{
			this.jc=jClient;
		}

		/// <summary>
		/// Initialize the attributes of the agent and create the components of acting, perception, and reasoning.
		/// </summary>
		/// <param name="rsn">Reasoning Class Instance</param>
		private void create(Reasoning rsn)
		{
			/*DEBUG*/
			//Debug.WriteLine("->Agent.create():Creating agent's ACTING component");
			acting=new Acting(jc);

			/*DEBUG*/
			//Debug.WriteLine("->Agent.create():Creating agent's REASONING component");
			reasoning=rsn;
			reasoning.setActing(acting);

			/*DEBUG*/
			//Debug.WriteLine("->Agent.create():Creating agent's PERCEPTION component");
			passivePerception=new PassivePerception();
			
			passivePerception.setReasoning(rsn);
		}

	}
}
